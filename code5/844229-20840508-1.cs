    Page.Response.ContentType = "text/xml";
            // Read XML posted via HTTP
            StreamReader reader = new StreamReader(Page.Request.InputStream);
            string xmlData = reader.ReadToEnd();
            sw.Write(xmlData);
            sw.Close();
