    public void OnPictureTaken(byte[] data, Android.Hardware.Camera camera)
    {
        // Save the image JPEG data to the SD card
        FileOutputStream outStream = null;
        File dataDir = Android.OS.Environment.ExternalStorageDirectory;
        if (data!=null)
        {
			try
			{
				outStream = new FileOutputStream(dataDir + "/" + PICTURE_FILENAME);
				outStream.Write(data);
				outStream.Close();
			}
			catch (FileNotFoundException e)
			{
				Android.Util.Log.Debug("SIMPLECAMERA", e.Message);
			}
			catch (IOException e)
			{
				Android.Util.Log.Debug("SIMPLECAMERA", e.Message);
			}
			File file = new File(dataDir + "/" + PICTURE_FILENAME);
			try 
			{
				ExifInterface exif = new ExifInterface(file.CanonicalPath);
				// Read the camera model and location attributes
				exif.GetAttribute(ExifInterface.TagModel);
				float[] latLng = new float[2];
				exif.GetLatLong(latLng);
				// Set the camera make
				exif.SetAttribute(ExifInterface.TagMake, “My Phone”);
				exif.SetAttribute(ExifInterface.TagDatetime, 
				System.DateTime.Now.ToString());
			}
			catch (IOException e) {
				Android.Util.Log.Debug("SIMPLECAMERA", e.Message);
			}
        }
        else
        {
			Toast.MakeText(this, "No Image Captured", ToastLength.Long);
        }
     }
