    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Runtime.Serialization.Json;
    using System.ServiceModel;
    using System.Text;
    
    public interface ICommunication
            {
            string Communicate(string Uri,string Method, string Refrance, string ContentType, string Data);
            }
    
        public class JSONCommunication  :ICommunication
            {
            public JSONCommunication()
                {
    
                }
            #region ICommunication Members
            private CookieContainer Cookie = new CookieContainer();
            public string Communicate(string Uri, string Method, string Refrance, string ContentType, string Data)
                {
                HttpWebRequest web = (HttpWebRequest)WebRequest.Create(Uri);
                web.Method = Method;
                web.Referer = Refrance;
                web.ContentLength = Data.Length;
                web.CookieContainer = Cookie;
                //web.KeepAlive = true;
                web.ContentType = ContentType;
                if (Data != string.Empty && Method.ToUpper()!="GET")
                    {
                    using (var Request = web.GetRequestStream())
                        {
                        Request.Write(
                            ASCIIEncoding.Default.GetBytes(Data), 
                            0,
                            (int) web.ContentLength);
                        }
                    
                    }
                web.AllowAutoRedirect = true;
                var Response = web.GetResponse();
                var ResquestStream = Response.GetResponseStream();
                ICollection<byte> bt = new List<byte>();
                while (true)
                    {
                    int i = ResquestStream.ReadByte();
                    if (i == -1)
                        break;
                    bt.Add((byte)i);
                    }
                var output = ASCIIEncoding.Default.GetString(bt.ToArray());
                return output;
                }
    
            #endregion
            }
