            try
            {
                var doc = await docRepo.GetOriginalPDF(docid);
                if (doc != null)
                {
                    var result = Request.CreateResponse(HttpStatusCode.OK);
                    result.Headers.AcceptRanges.Add("none");
                    result.Content = new StreamContent(new MemoryStream(doc));
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                    result.Content.Headers.ContentLength = doc.Length;
                    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline")
                    {
                        FileName = "Client.pdf"
                    };
                    return this.ResponseMessage(result);
                }
                return this.NotFound();
            }
            catch
            {
                return this.InternalServerError();
            }
        }
