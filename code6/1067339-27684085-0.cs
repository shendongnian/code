    public class FileUploadsManager
    {
        //pass in the list of file paths which u want to upload.
        public static async void UploadFilesAsync(string[] filePaths)
        {
            List<Task> fileUploadingTasks = new List<Task>();
            foreach (var filePath in filePaths)
            {
                fileUploadingTasks.Add(UploadFileAsync(filePath));
            }
            await Task.WhenAll(fileUploadingTasks);
        }
        public static Task UploadFileAsync(string filePath)
        {
            return Task.Run(async () =>
            {
                //this is your code with a few changes
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(
                        string.Format("(secret)/{0}", Path.GetFileName(filePath))
                    );
                request.Method = WebRequestMethods.Ftp.UploadFile;
                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential("secret", "secret");
                // Copy the contents of the file to the request stream.
                StreamReader sourceStream = new StreamReader(filePath);
                byte[] fileContents = Encoding.UTF8.GetBytes(await sourceStream.ReadToEndAsync());
                sourceStream.Close();
                request.ContentLength = fileContents.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();
                FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync();
                Console.WriteLine("STOCK Upload File Complete, status {0}", response.StatusDescription);
                response.Close();
            });
        }
    }
