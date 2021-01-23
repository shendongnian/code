        ...
        private string GetBlobDataString(IDataReader openedDataReader, int columnIndex)
        {
            StringBuilder data = new StringBuilder(20000);
            char[] buffer = new char[1000];
            long startIndex = 0;
            long dataReceivedCount = openedDataReader.GetChars(columnIndex, startIndex, buffer, 0, 1000);
            data.Append(buffer, 0, (int)dataReceivedCount);
            while (dataReceivedCount == 1000)
            {
                startIndex += 1000;
                dataReceivedCount = openedDataReader.GetChars(columnIndex, startIndex, buffer, 0, 1000);
                data.Append(buffer, 0, (int)dataReceivedCount);
            }
            return data.ToString();
        }
        private byte[] GetBlobDataBinary(IDataReader openedDataReader, int columnIndex)
        {
            MemoryStream data = new MemoryStream(20000);
            BinaryWriter dataWriter = new BinaryWriter(data);
            byte[] buffer = new byte[1000];
            long startIndex = 0;
            long dataReceivedCount = openedDataReader.GetBytes(columnIndex, startIndex, buffer, 0, 1000);
            dataWriter.Write(buffer, 0, (int)dataReceivedCount);
            while (dataReceivedCount == 1000)
            {
                startIndex += 1000;
                dataReceivedCount = openedDataReader.GetBytes(columnIndex, startIndex, buffer, 0, 1000);
                dataWriter.Write(buffer, 0, (int)dataReceivedCount);
            }
            data.Position = 0;
            return data.ToArray();
        }
