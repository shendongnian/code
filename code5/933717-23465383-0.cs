    //Convert img into bytes
    byte[] FileBytes = null;
    string imgpath = "PatientsPhotos/" + lbl_patientID.Content.ToString() + ".jpg";
    FileStream fs = new FileStream(imgpath,System.IO.FileMode.Open,System.IO.FileAccess.Read);
    BinaryReader BR = new BinaryReader(fs);
    long allbytes = new FileInfo(imgpath).Length;
    FileBytes = BR.ReadBytes((Int32)allbytes);
    patient.imagepath = FileBytes;
