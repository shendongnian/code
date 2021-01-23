                image = context.FindExistingNode(NodeType.Image) as ImageGenerator;
                ImageMetaData imd = image.GetMetaData();
                lock (this)
                {
                    //**************************************//
                    //***********RGB Camera Feed************//
                    //**************************************//
                    Rectangle rect = new Rectangle(0, 0, this.bitmap.Width, this.bitmap.Height);
                    BitmapData data = this.camera_feed.LockBits(rect, ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    byte* pDest = (byte*)data.Scan0.ToPointer();
                    byte* imstp = (byte*)image.ImageMapPtr.ToPointer();
                    // set pixels
                    for (int i = 0; i < imd.DataSize; i += 3, pDest += 3, imstp += 3)
                    {
                        pDest[0] = imstp[2];
                        pDest[1] = imstp[1];
                        pDest[2] = imstp[0];
                    }
