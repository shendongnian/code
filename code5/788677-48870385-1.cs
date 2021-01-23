        public static string CopyImage(this WordprocessingDocument newDoc, string relId, WordprocessingDocument org)
        {
            var p = org.MainDocumentPart.GetPartById(relId) as ImagePart;
            var newPart = newDoc.MainDocumentPart.AddPart(p);
            newPart.FeedData(p.GetStream());
            return newDoc.MainDocumentPart.GetIdOfPart(newPart);
        }
