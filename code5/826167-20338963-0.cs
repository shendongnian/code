    PictureBox[] picBoxArray = new PictureBox[50];
    // 50 iterations for 50 object instantiations.
    for (int i=0; i<picBoxArray.Length; i++) {
        // create an pictureBox instance.
        picBoxArray[i] = new PictureBox();
    }
    PictureBox pb = null;
    // 50 iterations for calling methods on each of the 50 objects.
    for (int i=0; i<picBoxArray.Length; i++) {
        pb = picBoxArray[i];
        // do something with the picturebox e.g. pb.SetPicture(...)
    }
