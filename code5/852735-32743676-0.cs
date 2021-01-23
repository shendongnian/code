    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web.Script.Serialization;
    
    namespace ClientZone.External
    {
        public class FreeAgent
        {
            public enum Methods
            {
                POST = 1,
                PUT
            }
    
            public enum Status
            {
                Draft = 1,
                Sent,
                Cancelled
            }
    
            private string _subDomain;
            private string _identifier;
            private string _secret;
            private string _redirectURI;
            public static string AuthToken = "";
            private static string _accessToken = "";
            private static string _refreshToken = "";
            private static DateTime _refreshTime;
    
            public FreeAgent(string identifier, string secret, string subdomain, string redirectURI)
            {
                _subDomain = subdomain;
                _identifier = identifier;
                _secret = secret;
                _redirectURI = redirectURI; // If this was specified in the Auth Token call, you must specify it here, and it must be the same
            }
    
            public bool GetAccessToken()
            {
                try
                {
                    string url = @"https://api.freeagent.com/v2/token_endpoint";
                    WebClient client = new WebClient();
                    string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_identifier + ":" + _secret));
                    client.Headers[HttpRequestHeader.Host] = "api.freeagent.com";
                    client.Headers[HttpRequestHeader.KeepAlive] = "true";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.93 Safari/537.36";
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded;charset=UTF-8";
    
                    client.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;
                    System.Net.ServicePointManager.Expect100Continue = false;
                    client.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
                    client.Headers[HttpRequestHeader.AcceptLanguage] = "en-US,en;q=0.8";
    
                    var result = "";
                    if (!(_accessToken == "" && _refreshToken != ""))
                    {
                        string data = string.Format("grant_type=authorization_code&code={0}&redirect_uri={1}", AuthToken, _redirectURI);
                        result = client.UploadString(url, data);
                    }
                    else
                    {
                        // Marking the access token as blank and the refresh token as not blank
                        // is a sign we need to get a refresh token
                        string data = string.Format("grant_type=refresh_token&refresh_token={0}", _refreshToken);
                        result = client.UploadString(url, data);
                    }
    
                    JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                    var results_list = (IDictionary<string, object>)json_serializer.DeserializeObject(result);
                    _accessToken = results_list["access_token"].ToString();
                    int secondsUntilRefresh = Int32.Parse(results_list["expires_in"].ToString());
                    _refreshTime = DateTime.Now.AddSeconds(secondsUntilRefresh);
                    if (results_list.Any(x => x.Key == "refresh_token"))
                    {
                        _refreshToken = results_list["refresh_token"].ToString();
                    }
    
                    if (_accessToken == "" || _refreshToken == "" || _refreshTime == new DateTime())
                    {
                        return false;
                    }
    
                }
                catch
                {
                    return false;
                }
    
                return true;
            }
    
            private HttpStatusCode SendWebRequest(Methods method, string URN, string request, out string ResponseData)
            {
                if (_accessToken == "")
                {
                    // The access token has not been retrieved yet
                    GetAccessToken();
                }
                else
                {
                    if (_refreshTime != new DateTime() && _refreshTime < DateTime.Now) {
                        // The token has expired and we need to refresh it
                        _accessToken = "";
                        GetAccessToken();
                    }
                }
    
                if (_accessToken != "")
                {
                    try
                    {
                        WebClient client = new WebClient();
                        string url = "https://api.freeagentcentral.com/v2/" + URN;
                        client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.93 Safari/537.36";
                        client.Headers[HttpRequestHeader.Authorization] = "Bearer " + _accessToken;
                        client.Headers[HttpRequestHeader.ContentType] = "application/json";
                        client.Headers[HttpRequestHeader.Accept] = "application/json";
    
                        if (method == Methods.POST || method == Methods.PUT)
                        {
                            string data = request;
                            var result = client.UploadString(url, method.ToString(), data);
                            ResponseData = result;
                            return HttpStatusCode.Created;
                        }
                        else
                        {
                            var result = client.DownloadString(url);
                            ResponseData = result;
                            return HttpStatusCode.OK;
                        }
                    }
                    catch (WebException e)
                    {
                        if (e.GetType().Name == "WebException")
                        {
                            WebException we = (WebException)e;
                            HttpWebResponse response = (System.Net.HttpWebResponse)we.Response;
    
                            ResponseData = response.StatusDescription;
                            return response.StatusCode;
                        }
                        else
                        {
                            ResponseData = e.Message;
                            if (e.InnerException != null)
                            {
                                ResponseData = ResponseData + " - " + e.InnerException.ToString();
                            }
                            return HttpStatusCode.SeeOther;
                        }
                    }
                }
                else
                {
                    ResponseData = "Access Token could not be retrieved";
                    return HttpStatusCode.SeeOther;
                }
            }
    
            private int ExtractNewID(string resp, string URN)
            {
                if (resp != null && resp.Trim() != "")
                {
                    JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                    var results_list = (IDictionary<string, object>)json_serializer.DeserializeObject(resp);
    
                    if (results_list.Any(x => x.Key == "invoice"))
                    {
                        var returnInvoice = (IDictionary<string, object>)results_list["invoice"];
    
                        if (returnInvoice["created_at"].ToString() != "")
                        {
                            string returnURL = returnInvoice["url"].ToString();
    
                            if (returnURL.Contains("http"))
                            {
                                return int.Parse(returnURL.Remove(0, ("https://api.freeagentcentral.com/v2/" + URN).Length + 1));
                            }
                            else
                            {
                                return int.Parse(returnURL.Remove(0, URN.Length + 2));
                            }
                        }
                    }
                }
    
                return -1;
            }
    
            public int CreateContact(string firstName, string lastName, string emailAddress, string street, string city, string state, string postcode, string country)
            {
                StringBuilder request = new StringBuilder();
    
                request.Append("{\"contact\":{");
                request.Append("\"first-name\":");
                request.Append(firstName);
                request.Append("\",");
                request.Append("\"last-name\":");
                request.Append(lastName);
                request.Append("\",");
                request.Append("\"email\":");
                request.Append(emailAddress);
                request.Append("\",");
    
                request.Append("\"address1\":");
                request.Append(street);
                request.Append("\",");
                request.Append("\"town\":");
                request.Append(city);
                request.Append("\",");
                request.Append("\"region\":");
                request.Append(state);
                request.Append("\",");
                request.Append("\"postcode\":");
                request.Append(postcode);
                request.Append("\",");
                request.Append("\"country\":");
                request.Append(country);
                request.Append("\"");
    
                request.Append("}");
    
                string returnData = string.Empty;
    
                HttpStatusCode responseCode = SendWebRequest(Methods.POST, "contacts", request.ToString(), out returnData);
                if (responseCode == HttpStatusCode.OK || responseCode == HttpStatusCode.Created)
                {
                    return ExtractNewID(returnData, "contacts");
                }
                else
                {
                    return -1;
                }
            }
    
            public int CreateInvoice(int contactID, DateTime invoiceDate, int terms, string reference, string comments, string currency = "GBP")
            {
                StringBuilder request = new StringBuilder();
    
                request.Append("{\"invoice\":{");
                request.Append("\"dated_on\": \"");
                request.Append(invoiceDate.ToString("yyyy-MM-ddTHH:mm:00Z"));
                request.Append("\",");
    
                if (!string.IsNullOrEmpty(reference))
                {
                    request.Append("\"reference\": \"");
                    request.Append(reference);
                    request.Append("\",");
                }
    
                if (!string.IsNullOrEmpty(comments))
                {
                    request.Append("\"comments\": \"");
                    request.Append(comments);
                    request.Append("\",");
                }
    
                request.Append("\"payment_terms_in_days\": \"");
                request.Append(terms);
                request.Append("\",");
    
                request.Append("\"contact\": \"");
                request.Append(contactID);
                request.Append("\",");
    
                if (currency == "EUR")
                {
                    request.Append("\"ec_status\": \"");
                    request.Append("EC Services");
                    request.Append("\",");
                }
    
                request.Append("\"currency\": \"");
                request.Append(currency);
                request.Append("\"");
    
                request.Append("}}");
    
                string returnData = string.Empty;
    
                HttpStatusCode responseCode = SendWebRequest(Methods.POST, "invoices", request.ToString(), out returnData);
                if (responseCode == HttpStatusCode.OK || responseCode == HttpStatusCode.Created)
                {
                    return ExtractNewID(returnData, "invoices");
                }
                else
                {
                    return -1;
                }
            }
    
            public bool ChangeInvoiceStatus(int invoiceID, Status status)
            {
                string returnData = string.Empty;
    
                HttpStatusCode resp = SendWebRequest(Methods.PUT, "invoices/" + invoiceID.ToString() + "/transitions/mark_as_" + status.ToString().ToLower(), string.Empty, out returnData);
    
                return false;
            }
    
            public int CreateInvoiceItem(int invoiceID, string itemType, float price, int quantity, float taxRate, string description)
            {
                StringBuilder request = new StringBuilder();
    
                request.Append("{\"invoice\":{");
                request.Append("\"invoice_items\":[{");
    
                request.Append("\"item_type\": \"");
                request.Append(itemType);
                request.Append("\",");
    
                request.Append("\"price\": \"");
                request.Append(price.ToString("0.00"));
                request.Append("\",");
    
                request.Append("\"quantity\": \"");
                request.Append(quantity);
                request.Append("\",");
    
                request.Append("\"sales_tax_rate\": \"");
                request.Append(taxRate.ToString("0.00"));
                request.Append("\",");
    
                request.Append("\"description\": \"");
                request.Append(description);
                request.Append("\"");
    
                request.Append("}]");
                request.Append("}");
                request.Append("}");
    
                string returnData = string.Empty;
    
                HttpStatusCode responseCode = SendWebRequest(Methods.PUT, "invoices/" + invoiceID.ToString(), request.ToString(), out returnData);
                if (responseCode == HttpStatusCode.OK || responseCode == HttpStatusCode.Created)
                {
                    // Invoice items is an update call to an invoice, so we just get a 200 OK with no response body to extract an ID from
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
