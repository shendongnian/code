    public KeyValuePair<string, FileDetails> UploadModelWithFile(Book book)
            {
               var file = book.File;
                var reader = new StreamReader(file.OpenReadStream());
                var fileContent = reader.ReadToEnd();
                var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                var fileDetails = new FileDetails
                {
                    Filename = parsedContentDisposition.FileName,
                    Content = fileContent
                };
    
                return new KeyValuePair<string, FileDetails>(book.Name, fileDetails);
            }
