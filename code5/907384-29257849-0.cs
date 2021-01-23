        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using Windows.Web.Http;
        namespace yourfancyNamespace
        {
            public static class IHttpContentExtension
            {
                public static async Task<string> ReadAsStringUTF8Async(this IHttpContent content)
                {
                    return await content.ReadAsStringAsync(Encoding.UTF8);
                }
                public static async Task<string> ReadAsStringAsync(this IHttpContent content, Encoding encoding)
                {
                    using (TextReader reader = new StreamReader((await content.ReadAsInputStreamAsync()).AsStreamForRead(), encoding))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
