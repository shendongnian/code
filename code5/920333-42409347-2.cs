    public string BlobToStringConverter(OracleDbType.Blob blobObject){
        if (blobObject != null){
            return  Encoding.UTF8.GetString((byte[])(blobObject));
        } else {
            return string.Empty; 
        }
    }
