    private async Task<IInputStream> GetInputStreamFromIOStream(System.IO.Stream stream, long fileSize)
        {
            try
            {
                BinaryReader binReader = new BinaryReader(stream);
                byte[] byteArr = binReader.ReadBytes((int)fileSize);
                var iMS = new InMemoryRandomAccessStream();
                var imsOutputStream = iMS.GetOutputStreamAt(0);
                DataWriter dataWriter = new DataWriter(imsOutputStream);
                dataWriter.WriteBytes(byteArr);
                await dataWriter.StoreAsync();
                await imsOutputStream.FlushAsync();
                return iMS.GetInputStreamAt(0);
            }
            catch(Exception ex)
            {
                //Error Handling here
                return null;
            }
        }
