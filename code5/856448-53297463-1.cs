    public class Test
    {
        private async void Upload(String filePath, CloudBlockBlob blob)
        {
            ObservableFileStream fs = null;
            using (fs = new ObservableFileStream(filePath, FileMode.Open, (current) =>
            {
                Console.WriteLine("Uploading " + ((double)current / (double)fs.Length) * 100d);
            }))
            {
                await blob.UploadFromStreamAsync(fs);
            }
        }
    }
