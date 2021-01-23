        /// <summary>
        /// Import files from filesystem to the database
        /// </summary>
        /// <remarks>This is a heavy one-time operation. If used on a job, it should run off-peak</remarks>
        public void ImportFileSystemToDatabase()
        {
            string fileImportFolder = ConfigurationManager.AppSettings["FileImportPath"];
            string fileStorage = ConfigurationManager.AppSettings["FileStoragePath"];
            var filesToImport = Directory.GetFiles(fileImportFolder, "*", SearchOption.AllDirectories);
            foreach (var filePath in filesToImport)
            {
                var file = new FileInfo(filePath);
                string[] treePath = filePath.Replace(fileImportFolder, "").Split('\\');
                DocumentFile newDocument = new DocumentFile
                {
                    MimeType = file.Extension,
                    FileName = file.Name,
                    Active = true,
                    CreationDate = DateTime.Now,
                    CreationUser = "IMPORT",
                    FilePath = fileStorage + "\\" + file.Name
                };
                
                //Lets contextualize the document to the object Id
                int adjReId = Convert.ToInt32(treePath[1]);
                //Context goes here
                if (treePath.Count() == 4)
                {
                    //Lets set the Category
                    newDocument.CategoryId = CreateDocumentCategory(treePath[2], (int)LookupTypes.DocumentCategories);
                }
                if (treePath.Count() > 4)
                {
                    //Lets set the Category
                    newDocument.CategoryId = CreateDocumentCategory(treePath[2], (int)LookupTypes.DocumentCategories);
                    //Lets set the SubCategory
                    newDocument.CategoryId = CreateDocumentCategory(treePath[3], (int)LookupTypes.DocumentSubCategories);
                }
                file.CopyTo(fileStorage + file.Name);
                
                InsertDocumentFile(newDocument);
            }
        }
