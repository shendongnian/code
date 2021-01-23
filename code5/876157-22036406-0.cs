            Response.ContentType = "application/rss+xml";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(builder.ToString());
            xmlDoc.Save(Response.OutputStream);
            Response.End();
