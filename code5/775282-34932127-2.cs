    BlobCounter blobCounter = new BlobCounter();
    blobCounter.ProcessImage((Bitmap)pictureBox1.Image);
    Blob[] blobs = blobCounter.GetObjectsInformation();
    List<IntPoint> leftPoints;
    List<IntPoint> rightPoints;
    foreach (Blob blob in blobs)
    {
         blobCounter.GetBlobsLeftAndRightEdges(blob, out leftPoints, out rightPoints);
    }
