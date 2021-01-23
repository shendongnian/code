    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace WannaSport.Data.Integration
    {
        public static class HttpContentExtension
        {
            public static async Task<string> ReadAsStringUTF8Async(this HttpContent content)
            {
                return await content.ReadAsStringAsync(Encoding.UTF8);
            }
    
            public static async Task<string> ReadAsStringAsync(this HttpContent content, Encoding encoding)
            {
                using (var reader = new StreamReader((await content.ReadAsStreamAsync()), encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
