    using System;
    using System.Collections.Specialized;
    using System.Net;
    using CsQuery;
    namespace NMClient
    {
        public struct Price
        {
            public string Currency;
            public decimal Value;
        }
        public class NMWebClient : WebClient
        {
            private const string TARGET_CURRENCY = "USD";
            private const string TARGET_CURRENCY_SWITCH_DATA = "$b64$eyJDb250ZXh0Q2hvb3NlclJlcSI6eyJjb3VudHJ5IjoiTUMiLCJjdXJyZW5jeSI6IlVTRCIsImxhbmd1YWdlIjoiZW4ifX0$";
            private CookieContainer _container;
            public NMWebClient()
            {
                _container = new CookieContainer();
            }
            protected override WebRequest GetWebRequest(Uri address)
            {
                var request = base.GetWebRequest(address);
                var httpRequest = request as HttpWebRequest;
                if (httpRequest != null)
                {
                    httpRequest.CookieContainer = this._container;
                    return httpRequest;
                }
                else
                {
                    return request;
                }
            }
            public static string GetTimestamp()
            {
                return DateTime.Now.ToString("yyyyMMddHHmmssffff");
            }
            public void SetCurrencyToUsDollars()
            {
                const string serviceUri = "http://www.neimanmarcus.com/en-mc/ajax.service";
                var values = new NameValueCollection();
                values.Add("data", TARGET_CURRENCY_SWITCH_DATA);
                values.Add("timestamp", GetTimestamp());
                this.UploadValues(serviceUri, values);
            }
            public decimal GetUSDPriceValue(string uri)
            {
                var price = GetPrice(uri);
                if (price.Currency != TARGET_CURRENCY)
                {
                    SetCurrencyToUsDollars();
                    price = GetPrice(uri);
                    if (price.Currency != TARGET_CURRENCY)
                    {
                        throw new Exception("Can't switch price to " + TARGET_CURRENCY);
                    }
                }
                return price.Value;
            }
            private Price GetPrice(string uri)
            {
                string price = GetPriceText(uri);
                int priceSeparator = price.IndexOf(' ');
                return new Price()
                {
                    Currency = price.Substring(0, priceSeparator),
                    Value = Convert.ToDecimal(price.Substring(priceSeparator + 1))
                };
            }
            private string GetPriceText(string uri)
            {
                var html = this.DownloadString(uri);
                var cq = CQ.Create(html);
                var priceElement = cq.Select("[itemprop=price]");
                return priceElement.Text().Trim();
            }
        }
    }
