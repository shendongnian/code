    using System;  
    using System.Drawing;  
    using System.Drawing.Imaging;  
    using System.IO;  
    using System.Net;  
    namespace SaveImage
    {
    class Program
    {
        static void Main(string[] args)
        {
            using (Image image = DownloadImage(new Uri("http://www.hdwallpapersview.com/wp-content/uploads/2013/10/30/omg-funny-animals-dog-1.jpg")))
            {
                image.Save("temp.jpg", ImageFormat.Jpeg);
            }
        }
        public static Image DownloadImage(Uri url)
        {
            Image result = null;
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
                WebResponse webResponse = webRequest.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream())
                {
                    using (Image tempImage = Image.FromStream(webStream))
                    {
                        result = new Bitmap(tempImage);
                    }
                }
                webResponse.Close();
            }
            catch (Exception e)
            {
                return null;
            }
            return result;
        }
    }
}
