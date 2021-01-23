                    byte[] ResponseStream = objConnection.GetStream(letterNumber, paperType);
                    HttpResponseMessage apiResponse;
                        apiResponse = new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new ByteArrayContent(ResponseStream)
                        };
                        apiResponse.Content.Headers.ContentLength = ResponseStream.Length;
                        apiResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                        apiResponse.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                        {
                            FileName = String.Format("Letter_" + letterNumber + ".pdf")
                        };
