       public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            System.IO.Stream body = context.Request.InputStream;
            System.Text.Encoding encoding = context.Request.ContentEncoding;
            System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
            string s = reader.ReadToEnd();
            Noticia publicacion = JsonConvert.DeserializeObject<Noticia>(s);
            var capaSeguridad = new { d = publicacion.Categoria };
            context.Response.Write(JsonConvert.SerializeObject(capaSeguridad));
        }
