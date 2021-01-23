            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                string fileName = "";
                string fileLocalName = "";
                var result = await Request.Content.ReadAsMultipartAsync(provider);
                foreach (MultipartFileData file in provider.FileData)
                {
                    fileLocalName = file.LocalFileName;
                }
                File.WriteAllBytes(@"C:\temp\output.xlsx", File.ReadAllBytes(fileLocalName));
            }
