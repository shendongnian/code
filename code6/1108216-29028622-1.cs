    public static void CreateAndUploadFile(List list, string filePath, IDictionary<string, object> itemProperties)
    {
        using (var document = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
        {
            var mainPart = document.AddMainDocumentPart();
            mainPart.Document = new Document(new Body());
        }
        UploadFile(list, filePath, itemProperties);
    }
