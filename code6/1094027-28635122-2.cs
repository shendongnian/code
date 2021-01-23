    public void AddContentFileCurl(byte[] file, string name, string filename)
        {
            string header = string.Format("--{0}", boundary);
            string fileContentType = MIMEAssistant.GetMIMEType(filename);                       
            contents.AppendLine(header);
            string fileHeader=String.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"",name,filename);
            string fileData = Encoding.UTF8.GetString(file);
            contents.AppendLine(fileHeader);
            contents.AppendLine(String.Format("Content-Type: {0}", fileContentType));
            contents.AppendLine();
            contents.AppendLine(fileData);
        }
    public void AddContentFormCurl(byte[] file, string name)
        {
            string header = string.Format("--{0}", boundary);
            contents.AppendLine(header);
            string fileHeader = String.Format("Content-Disposition: form-data; name=\"{0}\"", name);
            string fileData = Encoding.UTF8.GetString(file);
            contents.AppendLine(fileHeader);
            contents.AppendLine();
            contents.AppendLine(fileData);
        }
    public void LastFileAddedCurl()
        {
            string footer = string.Format("--{0}--", boundary);         
            contents.AppendLine(footer);
            string cstring = contents.ToString();
            byte[] bytes = Encoding.UTF8.GetBytes(cstring);
            if (content != null)
            {
                content = Bytes.Combine(content, bytes);
            }
            else
            {
                content = bytes;
            }
        }
