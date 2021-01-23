            FileStream fs = File.OpenRead(_fullPath);
            StreamContent streamContent = new StreamContent(fs);
            streamContent.Headers.Add("Content-Type", "application/octet-stream");
            String headerValue = "form-data; name=\"Filedata\"; filename=\"" + _Filename + "\"";
            byte[] bytes = Encoding.UTF8.GetBytes(headerValue);
            headerValue="";
            foreach (byte b in bytes)
            {
                headerValue += (Char)b;
            }
            streamContent.Headers.Add("Content-Disposition", headerValue);
            multipart.Add(streamContent, "Filedata", _Filename);
