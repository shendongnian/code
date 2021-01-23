    try
    {
       client.DownloadFile(img, localFilename);
    }
    catch (Exception)
    {
       MessageBox.Show("There was a problem downloading the file");
       continue; // terminate current loop...
    }
