        public FileInfo CreateAuditFile(AuditFile auditFile)
        {
            Request<AuditFile> request = new Request<AuditFile>();
            request.Parameter = auditFile;
            response = Client.PostAsJsonAsync("api/excel/createauditfile", request).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var responseData = JsonConvert.DeserializeObject<Response<FileInfo>>(data);
                if (!responseData.IsSuccessStatusCode)
                {
                    Exception ex = responseData.exception;
                    throw ex;
                }
                return responseData.Result;
            }
            else
            {
                throw new Exception("An unexpected Service Exception has Happened.  Please contact your administrator.");
            }
        }
