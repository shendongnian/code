    using (Stream output = new FileStream(outputFile, FileMode.Create))
    {
       foreach(BitmapFrame frame in decoder.Frames)
       {                   
            JpegBitmapEncoder enc = new JpegBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create(frame));
            enc.Save(output); //It overrides and finally i get the last image only
            //  outStream.CopyTo(output); this also not working.       
       }
     }
