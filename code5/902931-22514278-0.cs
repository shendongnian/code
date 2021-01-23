    // if you are using a PictureBox to draw the shapes, then convert it to a bitmap
    Bitmap bitmap = new Bitmap(pictureBox1.Image)
    // locate objects using blob counter
    BlobCounter blobCounter = new BlobCounter( );
    blobCounter.ProcessImage( bitmap );
    Blob[] blobs = blobCounter.GetObjectsInformation( );
    
    // create Graphics object to draw on the image and a pen
    Graphics g = Graphics.FromImage( bitmap );
    Pen bluePen = new Pen( Color.Blue, 2 );
    // check each object and draw circle around objects, which are recognized as circles
    for ( int i = 0, n = blobs.Length; i < n; i++ )
    {
        List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints( blobs[i] );
        List<IntPoint> corners = PointsCloud.FindQuadrilateralCorners( edgePoints );
    
        g.DrawPolygon( bluePen, ToPointsArray( corners ) );    
    }
    bluePen.Dispose( );
    g.Dispose( );
