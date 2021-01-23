        public static async Task DeleteAsync(string id)
        {
            Document doc = GetDocument(id);
            await Client.DeleteDocumentAsync(doc.SelfLink);
        }
