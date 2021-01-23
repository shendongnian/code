    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    
    public class GooglePageRank
    {
        /// <summary>
        /// Returns the PageRank of the given URL. Return values are 0 through 10 or
        /// -1 (N/A), which indicates there was an error or the URL is not in the
        /// Google index.
        /// </summary>
        /// <param name="url">URL to test</param>
        /// <returns></returns>
        public static int GetPageRank(string url)
        {
            int rank = -1;
    
            try
            {
                // Form complete URL
                url = String.Format("http://toolbarqueries.google.com/tbr" +
                    "?client=navclient-auto&features=Rank&ch={0}&q=info:{1}",
                    ComputeHash(url), UrlEncode(url));
    
                // Download page
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                StreamReader stream = new StreamReader(request.GetResponse().GetResponseStream());
                string response = stream.ReadToEnd();
    
                // Parse page rank value
                string[] arr = response.Split(':');
                if (arr.Length == 3)
                    rank = int.Parse(arr[2]);
            }
            catch (Exception)
            {
                // Do nothing but return -1;
            }
            return rank;
        }
    
        /// <summary>
        /// URL-encodes the given URL. Handy when HttpUtility is not available
        /// </summary>
        /// <param name="url">URL to encode</param>
        /// <returns></returns>
        private static string UrlEncode(string url)
        {
            StringBuilder builder = new StringBuilder();
    
            foreach (char c in url)
            {
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9'))
                    builder.Append(c);
                else if (c == ' ')
                    builder.Append('+');
                else if ("()*-_.!".IndexOf(c) >= 0)
                    builder.Append(c);
                else
                    builder.AppendFormat("%{0:X2}", (byte)c);
            }
            return builder.ToString();
        }
    
        /// <summary>
        /// Computes a hash value required by Google
        /// </summary>
        private static string ComputeHash(string url)
        {
            UInt32 a, b;
            UInt32 c = 0xE6359A60;
            int k = 0;
            int len;
    
            // Modify URL
            url = string.Format("info:{0}", url);
    
            a = b = 0x9E3779B9;
            len = url.Length;
    
            while (len >= 12)
            {
                a += (UInt32)(url[k + 0] + (url[k + 1] << 8) + (url[k + 2] << 16) + (url[k + 3] << 24));
                b += (UInt32)(url[k + 4] + (url[k + 5] << 8) + (url[k + 6] << 16) + (url[k + 7] << 24));
                c += (UInt32)(url[k + 8] + (url[k + 9] << 8) + (url[k + 10] << 16) + (url[k + 11] << 24));
                Mix(ref a, ref b, ref c);
                k += 12;
                len -= 12;
            }
    
            c += (UInt32)url.Length;
            switch (len)
            {
                case 11:
                    c += (UInt32)(url[k + 10] << 24);
                    goto case 10;
                case 10:
                    c += (UInt32)(url[k + 9] << 16);
                    goto case 9;
                case 9:
                    c += (UInt32)(url[k + 8] << 8);
                    goto case 8;
                case 8:
                    b += (UInt32)(url[k + 7] << 24);
                    goto case 7;
                case 7:
                    b += (UInt32)(url[k + 6] << 16);
                    goto case 6;
                case 6:
                    b += (UInt32)(url[k + 5] << 8);
                    goto case 5;
                case 5:
                    b += (UInt32)(url[k + 4]);
                    goto case 4;
                case 4:
                    a += (UInt32)(url[k + 3] << 24);
                    goto case 3;
                case 3:
                    a += (UInt32)(url[k + 2] << 16);
                    goto case 2;
                case 2:
                    a += (UInt32)(url[k + 1] << 8);
                    goto case 1;
                case 1:
                    a += (UInt32)(url[k + 0]);
                    break;
                default:
                    break;
            }
            Mix(ref a, ref b, ref c);
            return string.Format("6{0}", c);
        }
    
        /// <summary>
        /// ComputeHash() helper method
        /// </summary>
        private static void Mix(ref UInt32 a, ref UInt32 b, ref UInt32 c)
        {
            a -= b; a -= c; a ^= c >> 13;
            b -= c; b -= a; b ^= a << 8;
            c -= a; c -= b; c ^= b >> 13;
            a -= b; a -= c; a ^= c >> 12;
            b -= c; b -= a; b ^= a << 16;
            c -= a; c -= b; c ^= b >> 5;
            a -= b; a -= c; a ^= c >> 3;
            b -= c; b -= a; b ^= a << 10;
            c -= a; c -= b; c ^= b >> 15;
        }
    }
