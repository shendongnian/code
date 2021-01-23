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
    
            using (var client = new WebClient()) {
                encodedVideo = client.DownloadString(videoUrl);
            }
            NameValueCollection video = HttpUtility.ParseQueryString(encodedVideo);
            string encodedStreamsCommaDelimited = video["url_encoded_fmt_stream_map"];
            string[] encodedStreams = encodedStreamsCommaDelimited.Split(new char[]{','});
            var streams = encodedStreams.Select(s => HttpUtility.ParseQueryString(s));
            var streamsByPriority = streams.OrderBy(s => Array.IndexOf(itagByPriority, s["itag"]));
            NameValueCollection preferredStream = streamsByPriority.LastOrDefault();
    
            if (preferredStream != null) {
                Console.WriteLine("{0}&signature={1}", preferredStream["url"], preferredStream["sig"]);
            }
        }
    }
