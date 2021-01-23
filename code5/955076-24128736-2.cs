     public class FileUploadService : IFileUploadService
    {
        public bool UploadFileData(FileData fileData)
        {
            bool result = false;
            try
            {
                //Set the location where you want to save your file
                string FilePath = Path.Combine(ConfigurationManager.AppSettings["Path"], fileData.FileName);
                //If fileposition sent as 0 then create an empty file
                if (fileData.FilePosition == 0)
                {
                    File.Create(FilePath).Close();
                }
                //Open the created file to write the buffer data starting at the given file position
                using (FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                {
                    fileStream.Seek(fileData.FilePosition, SeekOrigin.Begin);
                    fileStream.Write(fileData.BufferData, 0, fileData.BufferData.Length);
                }
            }
            catch (Exception ex)
            {
                ErrorDetails ed = new ErrorDetails();
                ed.ErrorCode = 1001;
                ed.ErrorMessage = ex.Message;
                throw new FaultException<ErrorDetails>(ed);
            }
            return result;
        }
    }
