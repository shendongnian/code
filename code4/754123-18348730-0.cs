    private void photoChooserTaskComplete(object sender, PhotoResult e) {
    if (e.TaskResult == TaskResult.OK) {
           SaveToIsolatedStorage(e.ChosenPhoto,"Your File Name");           
    }
}
     public void SaveToIsolatedStorage(Stream imageStream, string fileName)
        {
            try
            {
                string imagename =  fileName + ".jpg";
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (myIsolatedStorage.FileExists(imagename))
                    {
                        myIsolatedStorage.DeleteFile(imagename);
                    }
                    IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile(imagename);
                    WriteableBitmap wb = new WriteableBitmap(100, 100);
                    wb.SetSource(imageStream);
                    wb.SaveJpeg(fileStream, 100, 100, 0, 70);
                    fileStream.Close();
                }
            }
            
            catch (Exception)
            {
                RadMessageBox.Show(String.Empty, MessageBoxButtons.OK, "Error occured while saving Images");                               
            }
        }
