            LibrariesManager librariesManager = LibrariesManager.GetManager();
            using(new ElevatedModeRegion(librariesManager))
            {
            
                Document pdfDocument = librariesManager.CreateDocument(documentID);
                DocumentLibrary parentLibrary = librariesManager.GetDocumentLibraries().Where(d => d.Id == certLibrary.Id).SingleOrDefault();
                pdfDocument.Parent = parentLibrary;
                pdfDocument.Title = pdfCertificationTitle;
                pdfDocument.DateCreated = DateTime.UtcNow;
                pdfDocument.PublicationDate = DateTime.UtcNow;
                pdfDocument.LastModified = DateTime.UtcNow;
                pdfDocument.UrlName = Regex.Replace(pdfCertificationTitle.ToLower(), @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-");
                librariesManager.RecompileAndValidateUrls(pdfDocument);
                librariesManager.Upload(pdfDocument, memStream, format);
                librariesManager.SaveChanges();
                var bag = new Dictionary<string, string>();
                bag.Add("ContentType", typeof(Document).FullName);
                                bool suppressSecurityChecks = WorkflowManager.GetManager().Provider.SuppressSecurityChecks;
                try
                {
                    WorkflowManager.GetManager().Provider.SuppressSecurityChecks = true;
                    WorkflowManager.MessageWorkflow(documentID, typeof(Document), null, "Publish", false, bag);
                }
                catch (Exception ex)
                {
                }
                finally 
                {
                    WorkflowManager.GetManager().Provider.SuppressSecurityChecks = suppressSecurityChecks;
                }  
          }
