    public Stream GenerateLicense(Stream period)
            {
                Stream result = new MemoryStream();
    
                StreamWriter sw = new StreamWriter(result);
                sw.Write("LICENSE");
                sw.Flush();
                result.Position = 0;
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                return result;
            }
