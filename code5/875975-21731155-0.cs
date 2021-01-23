    namespace SPUpload
    {
        class Program
        {
            static void Main(string[] args)
            {
                var attachmentUrl = AddAttachment(@"c:\temp\usermanual.rtf","Phones","1");
            }
    
    
            private static string AddAttachment(string filePath, string listName, string listItemId)
            {
                var listsSvc = new ListsService.Lists();
                listsSvc.Credentials = System.Net.CredentialCache.DefaultCredentials;
    
                var fileName = Path.GetFileName(filePath);
                var fileContent = File.ReadAllBytes(filePath);
                return listsSvc.AddAttachment(listName, listItemId, fileName, fileContent);
            }
        }
    }
