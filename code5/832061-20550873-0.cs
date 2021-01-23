    static public CookieContainer cookieJar;
      static void Main(string[] args)
        {
            string ControlNumber = "######";
            GetOrderInfo newOrder = new GetOrderInfo(ControlNumber);
            obtainCookies();
            MARICOPAcounty(newOrder.OrderAddress);
        }
    static void obtainCookies()
            {
                string postData = "http://mcassessor.maricopa.gov/";
                CookieContainer tempCookies = new CookieContainer();
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] byteData = encoding.GetBytes(postData);
    
                HttpWebRequest postReq = (HttpWebRequest)WebRequest.Create("http://mcassessor.maricopa.gov/");
                
                postReq.Method = "POST";
                postReq.KeepAlive = true;
                Cookie chocoChip = new Cookie("_ga", "GA1.2.1813386723.1386802842") { Domain = "http://mcassessor.maricopa.gov/" };
                
                postReq.CookieContainer = new CookieContainer();
                postReq.CookieContainer.Add(chocoChip);
                postReq.ContentType = "text/html; charset=utf-8";
                postReq.Referer = "http://mcassessor.maricopa.gov/";
                postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; MAM3; rv:11.0) like Gecko";
                postReq.ContentLength = byteData.Length;
    
                Stream postReqStream = postReq.GetRequestStream();
                postReqStream.Write(byteData, 0, byteData.Length);
                postReqStream.Close();
                HttpWebResponse postResponse;
    
                postResponse = (HttpWebResponse)postReq.GetResponse();
                postResponse.Cookies.Add(chocoChip);                           
                StreamReader postReqReader = new StreamReader(postResponse.GetResponseStream());
    
                tempCookies.Add(chocoChip);
                cookieJar = tempCookies;
                string soureCode = postReqReader.ReadToEnd();
    
                if (postReq != null)
                {
                    Console.WriteLine("\r\n\r\n postResponse COOKIES");
                    Console.WriteLine(postResponse.Cookies[0]);
    
                    Console.WriteLine("\r\n\r\n postReq Headers");
                    Console.WriteLine(postReq.Headers.ToString());
    
                    Console.WriteLine("\r\n\r\n postResponse Headers");
                    Console.Write("\t" + postResponse.Headers);
                }
            }
    
        public static string MARICOPAcounty(string Address)
    {
    //-------------------------------------------------------------------------------------------------------------------------------//
                //-------------------------------------------------------------------------------------------------------------------------------//
                Address = Address.Replace(" ", "+");
                string url1 = "http://mcassessor.maricopa.gov/?s=" + Address;
                HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(url1);
    
    
                request1.CookieContainer = cookieJar;                
                request1.Method = "GET";
                request1.Accept = "text/html, application/xhtml+xml, */*";
                request1.Headers.Add("Accept-Language: en-US");
                request1.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; MAM3; rv:11.0) like Gecko";
                request1.Headers.Add("Accept-Enconding: gzip, deflate");
    
                HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();
                StreamReader sr1 = new StreamReader(response1.GetResponseStream());
                string sourceCode1 = sr1.ReadToEnd();
                string ParcelNum = getBetween(sourceCode1, "http://treasurer.maricopa.gov/parcels/default.asp?Parcel=", "target=");
                ParcelNum = new String(ParcelNum.Where(Char.IsDigit).ToArray());
    
                if (response1 != null)
                {
                    Console.WriteLine("\r\n\r\n request1 Headers");
                    Console.WriteLine(request1.Headers.ToString());
    
                    Console.WriteLine("\r\n\r\nresponse1 Headers");
                    Console.Write("\t" + response1.Headers);
                }
    
                sr1.Close();
                response1.Close();
                //-------------------------------------------------------------------------------------------------------------------------------//
                //-------------------------------------------------------------------------------------------------------------------------------//
                //NEW GET request
    
                string url2 = "http://treasurer.maricopa.gov/parcels/default.asp?Parcel=50423370"; //+ ParcelNum;           
                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(url2);
    
                request2.CookieContainer = cookieJar;
                request2.Method = "GET";
                request2.Accept = "text/html, application/xhtml+xml, */*";
                request2.Headers.Add("Accept-Language: en-US");
                request2.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; MAM3; rv:11.0) like Gecko";
                request2.Headers.Add("Accept-Encoding: gzip, deflate");
                request2.Referer = url1;
    
                HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
                StreamReader sr2 = new StreamReader(response2.GetResponseStream());
                string sourceCode2 = sr2.ReadToEnd();
    
                if (response2 != null)
                {
                    Console.WriteLine("\r\n\r\nrrequest2 Headers");
                    Console.WriteLine(request2.Headers);
                    Console.WriteLine(request2.CookieContainer);
    
                    Console.WriteLine("\r\n\r\nresponse2 Headers");
                    Console.Write("\t" + response2.Headers);
                }
    
                sr2.Close();
                response2.Close();
    
                //-------------------------------------------------------------------------------------------------------------------------------//
                //-------------------------------------------------------------------------------------------------------------------------------//
                //new GET request
                string url3 = "http://treasurer.maricopa.gov/Parcel/TaxDetails.aspx?taxyear=2013";
                HttpWebRequest request3 = (HttpWebRequest)WebRequest.Create(url3);
    
                request3.CookieContainer = cookieJar;
                request3.Method = "GET";
                request3.Accept = "text/html, application/xhtml+xml, */*";
                request3.Headers.Add("Accept-Language: en-US");
                request3.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; MAM3; rv:11.0) like Gecko";
                request3.Headers.Add("Accept-Encoding: gzip, deflate");
                request3.Referer = url2;
    
                HttpWebResponse response3 = (HttpWebResponse)request3.GetResponse();
                StreamReader sr3 = new StreamReader(response3.GetResponseStream());
                string sourceCode3 = sr3.ReadToEnd();
    
                if (response3 != null)
                {
                    Console.WriteLine("\r\n\r\nrrequest3 Headers");
                    Console.WriteLine(request3.Headers);
    
                    Console.WriteLine("\r\n\r\nresponse3 Headers");
                    Console.Write("\t" + response3.Headers);
                }
    
                sr3.Close();
                response3.Close();
    
                return sourceCode3;
    }
