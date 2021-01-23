    if (param.Value is FileParameter)
    {
        FileParameter fileToUpload = (FileParameter)param.Value;
        string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: {3}\r\n\r\n",
                        boundary,
                        param.Key,
                        fileToUpload.FileName ?? String.Empty, //Change this line from 'fileToUpload.FileName ?? param.Key.' to 'fileToUpload.FileName ?? String.Empty,'
                        fileToUpload.ContentType ?? "application/octet-stream");
        formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));
        formDataStream.Write(fileToUpload.File, 0, fileToUpload.File.Length);
    }
    else
    {
        string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
                        boundary,
                        param.Key,
                        param.Value);
        formDataStream.Write(encoding.GetBytes(postData), 0, encoding.GetByteCount(postData));
    }
