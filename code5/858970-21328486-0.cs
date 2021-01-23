    [HttpPost]
        public HttpResponseMessage Post()
        {
            var request = HttpContext.Current.Request;
            HttpResponseMessage result = null;
            logHelper.LogExecute(() =>
            {
                if (request.Files.Count == 0)
                {
                    result = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                var resultFiles = new List<DatabaseFile>();
                using (var connection = sqlConnectionFactory.Create())
                using (var transaction = connection.BeginTransaction())
                {
                    for (var i = 0; i < request.Files.Count; i++)
                    {
                        var postedFile = request.Files[i];
                        var id = fileRepository.AddFile(postedFile.InputStream, postedFile.FileName, postFile.OrderId,
                                                        postFile.RootFolderName, connection, transaction);
                        resultFiles.Add(fileRepository.GetInfo(id, connection, transaction));
                    }
                    transaction.Commit();
                }
                result = Request.CreateResponse(HttpStatusCode.Created, resultFiles);
            });
            return result;
        }
