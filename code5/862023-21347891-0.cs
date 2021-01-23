    using System;
    using System.Linq;
    using HttpUtility = System.Web.HttpUtility;
    using NameValueCollection = System.Collections.Specialized.NameValueCollection;
    using WebClient = System.Net.WebClient;
    
    class Program {
        public static void Main(string[] args) {
            string videoID = "2FlgVN03fNM";
            string[] itagByPriority = {"5", "6", "34", "35"};
    
            string videoUrl = "https://www.youtube.com/get_video_info?asv=3&el=detailpage&hl=en_US&video_id=" + videoID;
            string encodedVideo = null;
    
            using (WebClient client = new WebClient()) {
                encodedVideo = client.DownloadString(videoUrl);
            }
    
            NameValueCollection video = HttpUtility.ParseQueryString(encodedVideo);
            
            NameValueCollection preferredStream = video["url_encoded_fmt_stream_map"].
                Split(new char[]{','}).
                Select(encodedStream => HttpUtility.ParseQueryString(encodedStream)).
                OrderBy(stream => Array.IndexOf(itagByPriority, stream["itag"])).
                LastOrDefault();
    
            if (preferredStream != null) {
                Console.WriteLine("{0}&signature={1}", preferredStream["url"], preferredStream["sig"]);
            }
        }
    }
