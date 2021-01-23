    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        [Route("{id}")]
        public HttpResponseMessage GetImage(int id)
        {
            HttpResponseMessage resp = new HttpResponseMessage();
            resp.Content = new PushStreamContent(async (responseStream, content, context) =>
            {
                await CopyBinaryValueToResponseStream(responseStream, id);
            });
            return resp;
        }
        // Application retrieving a large BLOB from SQL Server in .NET 4.5 using the new asynchronous capability
        private static async Task CopyBinaryValueToResponseStream(Stream responseStream, int imageId)
        {
            using (SqlConnection connection = new SqlConnection("your connection string here"))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("SELECT [bindata] FROM [Streams] WHERE [id]=@id", connection))
                {
                    command.Parameters.AddWithValue("id", imageId);
                    // The reader needs to be executed with the SequentialAccess behavior to enable network streaming
                    // Otherwise ReadAsync will buffer the entire BLOB into memory which can cause scalability issues or even OutOfMemoryExceptions
                    using (SqlDataReader reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess))
                    {
                        if (await reader.ReadAsync())
                        {
                            if (!(await reader.IsDBNullAsync(0)))
                            {
                                using (responseStream)
                                {
                                    using (Stream data = reader.GetStream(0))
                                    {
                                        // Asynchronously copy the stream from the server to the file we just created
                                        await data.CopyToAsync(responseStream);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
