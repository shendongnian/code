    using SeasideResearch.LibCurlNet;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace Scraping
    {
        public class LibCurlScraper
        {
            StringBuilder sb = new StringBuilder();
            MemoryStream ms = new MemoryStream();
            public string CookieFile { get; set; }
            public string RedirectUrl { get; set; }
            public string UserAgent { get; set; }
            public string ContentType { get; set; }
            public bool DisplayHeaders { get; set; }
            public bool FollowRedirects { get; set; }
    
            public LibCurlScraper()
            {
                UserAgent = "useragent";
                ContentType = "application/x-www-form-urlencoded";
                Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);
                DisplayHeaders = false;
            }
    
            private int MyWriteFunction(byte[] buf, int size, int nmemb, Object extraData)
            {
                foreach (byte b in buf)
                {
                    //Console.Write((char)b);
                    sb.Append((char)b);
                }
    
                return buf.Length;
            }
    
            private int MyWriteImageFunction(byte[] buf, int size, int nmemb, Object extraData)
            {
                foreach (byte b in buf)
                {
                    //Console.Write((char)b);
                    ms.WriteByte(b);
                }
    
                return buf.Length;
            }
    
            public MemoryStream LoadImage(string uri, string method = "GET", string postData = "", List<string> headers = null)
            {
                ms = new MemoryStream();
                Easy easy = new Easy();
                Easy.WriteFunction wf = MyWriteImageFunction;
                easy.SetOpt(CURLoption.CURLOPT_URL, uri);
                easy.SetOpt(CURLoption.CURLOPT_HEADER, false);
                easy.SetOpt(CURLoption.CURLOPT_FOLLOWLOCATION, true);
    
                Slist headerSlist = new Slist();
    
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        headerSlist.Append(header);
                    }
    
                }
    
                easy.SetOpt(CURLoption.CURLOPT_HTTPHEADER, headerSlist);
    
                easy.SetOpt(CURLoption.CURLOPT_SSL_VERIFYPEER, false);
                easy.SetOpt(CURLoption.CURLOPT_SSL_VERIFYHOST, false);
                easy.SetOpt(CURLoption.CURLOPT_USERAGENT, UserAgent);
                easy.SetOpt(CURLoption.CURLOPT_TIMEOUT, 10);
                easy.SetOpt(CURLoption.CURLOPT_CONNECTTIMEOUT, 3);
    
                if (!string.IsNullOrEmpty(postData))
                {
                    easy.SetOpt(CURLoption.CURLOPT_POST, true);
                    easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, postData);
                }
    
                easy.SetOpt(CURLoption.CURLOPT_COOKIEFILE, CookieFile);
                easy.SetOpt(CURLoption.CURLOPT_COOKIEJAR, CookieFile);
                easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
                easy.Perform();
                int code = 0;
                easy.GetInfo(CURLINFO.CURLINFO_RESPONSE_CODE, ref code);
                easy.Cleanup();
    
                return ms;
            }
    
            public override string Load(string uri, string method = "GET", string postData = "", List<string> headers = null)
            {
                sb.Clear();
                Easy easy = new Easy();
                Easy.WriteFunction wf = MyWriteFunction;
                easy.SetOpt(CURLoption.CURLOPT_URL, uri);
                easy.SetOpt(CURLoption.CURLOPT_HEADER, DisplayHeaders);
                easy.SetOpt(CURLoption.CURLOPT_FOLLOWLOCATION, FollowRedirects);
    
                Slist headerSlist = new Slist();
    
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        headerSlist.Append(header);
                    }
    
                }
    
                easy.SetOpt(CURLoption.CURLOPT_HTTPHEADER, headerSlist);
    
    
                easy.SetOpt(CURLoption.CURLOPT_SSL_VERIFYPEER, false);
                easy.SetOpt(CURLoption.CURLOPT_SSL_VERIFYHOST, false);
                easy.SetOpt(CURLoption.CURLOPT_USERAGENT, UserAgent);
                easy.SetOpt(CURLoption.CURLOPT_TIMEOUT, 10);
                easy.SetOpt(CURLoption.CURLOPT_CONNECTTIMEOUT, 3);
    
                if (!string.IsNullOrEmpty(postData))
                {
                    easy.SetOpt(CURLoption.CURLOPT_POST, true);
                    easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, postData);
                }
    
                if (method.Equals("POST"))
                {
                    easy.SetOpt(CURLoption.CURLOPT_POST, true);
                }
    
                easy.SetOpt(CURLoption.CURLOPT_COOKIEFILE, CookieFile);
                easy.SetOpt(CURLoption.CURLOPT_COOKIEJAR, CookieFile);
                easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
                easy.Perform();
                int code = 0;
                easy.GetInfo(CURLINFO.CURLINFO_RESPONSE_CODE, ref code);
                easy.Cleanup();
    
                //Console.WriteLine(code);
                if (code == 302)
                {
                    RedirectUrl = FindString(sb.ToString(), "Location:(.*?)\n");
                    //Console.WriteLine(RedirectUrl);
                }
    
    
                string page = sb.ToString();
                page = page.Replace("\r\n", ""); // strip all new lines and tabs
                page = page.Replace("\r", ""); // strip all new lines and tabs
                page = page.Replace("\n", ""); // strip all new lines and tabs
                page = page.Replace("\t", ""); // strip all new lines and tabs
    
                page = Regex.Replace(page, @">\s+<", "><");
    
                return page;
            }
    
            public static void OnDebug(CURLINFOTYPE infoType, String msg, Object extraData)
            {
                Console.WriteLine(msg);
                TextWriter tw = new StreamWriter(@"C:\cookies\verbose.txt", true);
                tw.WriteLine(msg);
                tw.Close();
            }
        }
    }
