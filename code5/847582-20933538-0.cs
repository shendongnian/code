    void Kinect_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {             
                using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
                {
                    if (depthFrame != null)
                    {                                              
                        this.depthFrame32 = new byte[depthFrame.Width * depthFrame.Height * 4];
                        //Update the image to the new format
                        this.depthPixelData = new short[depthFrame.PixelDataLength];
                        depthFrame.CopyPixelDataTo(this.depthPixelData);
                        byte[] convertedDepthBits = this.ConvertDepthFrame(this.depthPixelData, ((KinectSensor)sender).DepthStream);
                        Bitmap bmap = new Bitmap(depthFrame.Width, depthFrame.Height, PixelFormat.Format32bppRgb);
                        BitmapData bmapdata = bmap.LockBits(new Rectangle(0, 0, depthFrame.Width, depthFrame.Height), ImageLockMode.WriteOnly, bmap.PixelFormat);
                        IntPtr ptr = bmapdata.Scan0;
                        Marshal.Copy(convertedDepthBits, 0, ptr, 4 * depthFrame.PixelDataLength);
                        bmap.UnlockBits(bmapdata);
                        pictureBox2.Image = bmap;
                    }
                }
            }     
      private byte[] ConvertDepthFrame(short[] depthFrame, DepthImageStream depthStream)
        {
            //Run through the depth frame making the correlation between the two arrays
            for (int i16 = 0, i32 = 0; i16 < depthFrame.Length && i32 < this.depthFrame32.Length; i16++, i32 += 4)
            {
                // Console.WriteLine(i16 + "," + i32);
                //We don’t care about player’s information here, so we are just going to rule it out by shifting the value.
                int realDepth = depthFrame[i16] >> DepthImageFrame.PlayerIndexBitmaskWidth;
                //We are left with 13 bits of depth information that we need to convert into an 8 bit number for each pixel.
                //There are hundreds of ways to do this. This is just the simplest one.
                //Lets create a byte variable called Distance.
                //We will assign this variable a number that will come from the conversion of those 13 bits.
                byte Distance = 0;
                //XBox Kinects (default) are limited between 800mm and 4096mm.
                int MinimumDistance = 800;
                int MaximumDistance = 4096;
                //XBox Kinects (default) are not reliable closer to 800mm, so let’s take those useless measurements out.
                //If the distance on this pixel is bigger than 800mm, we will paint it in its equivalent gray
                if (realDepth > MinimumDistance)
                {
                    //Convert the realDepth into the 0 to 255 range for our actual distance.
                    //Use only one of the following Distance assignments
                    //White = Far
                    //Black = Close
                    //Distance = (byte)(((realDepth – MinimumDistance) * 255 / (MaximumDistance-MinimumDistance)));
                    //White = Close
                    //Black = Far
                    Distance = (byte)(255 - ((realDepth - MinimumDistance) * 255 / (MaximumDistance - MinimumDistance)));
                    //Use the distance to paint each layer (R G &  of the current pixel.
                    //Painting R, G and B with the same color will make it go from black to gray
                    this.depthFrame32[i32 + RedIndex] = (byte)(Distance);
                    this.depthFrame32[i32 + GreenIndex] = (byte)(Distance);
                    this.depthFrame32[i32 + BlueIndex] = (byte)(Distance);
                }
                //If we are closer than 800mm, the just paint it red so we know this pixel is not giving a good value
                else
                {
                    this.depthFrame32[i32 + RedIndex] = 0;
                    this.depthFrame32[i32 + GreenIndex] = 0;
                    this.depthFrame32[i32 + BlueIndex] = 0;
                }
            }
