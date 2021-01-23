        public static HttpWebResponse MultipartFormDataPost(string postUrl, string userAgent, byte[] data)
        {
            string contentType;
            byte[] formData = Program.GetMultipartFormData(data, out contentType);  
            return PostForm(postUrl, userAgent, contentType, formData);
        }
        public static byte[] GetMultipartFormData(byte[] data, out string contentType)
        {
            var byteArrayContent = new ByteArrayContent(data);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            byteArrayContent.Headers.Add("image_content", "myimage.jpeg");
            var content = new MultipartFormDataContent(String.Format("----------{0:N}", Guid.NewGuid())) { byteArrayContent };
            contentType = content.Headers.ContentType.ToString();
            return content.ReadAsByteArrayAsync().Result;
        }
    
