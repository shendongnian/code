    encoderParameters.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Transformation, (long)System.Drawing.Imaging.EncoderValue.TransformRotate90);
    //edited = true;
    pi.Value[0] = 1;
    im.SetPropertyItem(pi);
    // Added new memorystream
    System.IO.MemoryStream ms = new MemoryStream();
    // Read into memorystream
    im.Save(ms, GetEncoder(sourceFormat), encoderParameters);
    fs.Close();
    File.Delete(item);
    // Read from memorystream into byte array
    byte[] ni = ms.ToArray();
    // Save out using new filestream.
    using (FileStream nfs = new FileStream(item, FileMode.Create, FileAccess.ReadWrite)){
        nfs.Write(ni, 0, ni.Length);
    }
    //im.Save(item, GetEncoder(sourceFormat), encoderParameters);
