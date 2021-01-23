    Try
    {
    SPFile spFile = currentWeb.GetFile(excelFileUrl); // give url of ur xlsx file on hive
    string localFileName = Path.Combine(tempFilePath, string.Format("{0}.xlsx",    Guid.NewGuid().ToString("n"))); // tenpFilePath is where u wanna save ur file
    FileStream outStream = new FileStream(localFileName, FileMode.Create);
    byte[] fileData = spFile.OpenBinary();
    outStream.Write(fileData, 0, fileData.Count());
    outStream.Close();
    }
    catch(Exception ex)
    {
      throw ex;
    }
    
