    public class Base64MultipartFileStreamProvider : MultipartFileStreamProvider
    {
        ///
        // Add the constructors you need and call base
        //
        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {
            string filename = GetLocalFileName(headers);
            string localFilePath = Path.Combine(_rootPath, Path.GetFileName(filename));
            // Add local file name 
            MultipartFileData fileData = new MultipartFileData(headers, localFilePath);
            _fileData.Add(fileData);
            var stream = File.Create(localFilePath, _bufferSize, FileOptions.Asynchronous);
            // The following line is the wrapper
            return new CryptoStream(stream, new FromBase64Transform(), CryptoStreamMode.Write);
        }
    }
