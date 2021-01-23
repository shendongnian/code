    class DocumentGroupComparer : IEqualityComparer<DocumentGroup>
    {
        public bool Equals(DocumentGroupx, DocumentGroupy)
        {
            return x.Id == y.Id;
        }
        public int GetHashCode(DocumentGroup obj)
        {
            return obj.Id.GetHashCode();
        }
    }
    var documentGroups = DocumentTypes
        .Select(x => x.DocumentGroup)
        .Distinct(new DocumentGroupComparer())
        .ToList();
