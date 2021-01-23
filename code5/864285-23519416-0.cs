    byte[] buffer = new byte[BUFFER_SIZE];                
    GetObjectRequest getObjRequest = new GetObjectRequest().WithBucketName(Bucket_Name).WithKey(Object_Key);
    using (GetObjectResponse getObjRespone = amazonS3Client.GetObject(getObjRequest))
    using (Stream amazonStream = getObjRespone.ResponseStream)
    {
        int bytesReaded = 0;        
        Response.AddHeader("Content-Length", getObjRespone.ContentLength.ToString());
        while ((bytesReaded = amazonStream.Read(buffer, 0, buffer.Length)) > 0 && Response.IsClientConnected)
        {
            Response.OutputStream.Write(buffer, 0, bytesReaded);
            Response.OutputStream.Flush();
            buffer = new byte[BUFFER_SIZE];
        }
    }
