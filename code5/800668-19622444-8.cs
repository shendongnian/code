    int ISampleGrabberCB.BufferCB(double sampleTime, IntPtr buffer, int bufferLength)
        {           
                
                Debug.Assert(bufferLength == Math.Abs(pitch) * videoHeight, "Wrong Buffer Length"); 
                Debug.Assert(imageBuffer != IntPtr.Zero, "Remove Buffer");
                Decode(imageBuffer);   
                
            
            return 0;
        }
    public Image Decode(IntPtr imageData)
        {
            var bitmap = new Bitmap(width, height, pitch, PixelFormat.Format24bppRgb, imageBuffer);
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            Form1 form1 = new Form1("", "", "");
            form1.changepicturebox3(bitmap);
            bitmap.Save("C:\\Users\\...\\Desktop\\A2 Project\\barcode.jpg");
            return bitmap;
        }
