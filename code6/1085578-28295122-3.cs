    class RowViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Value { get; set; }
        public bool IsEditing { get; set; } //implement notify property changed
    }
