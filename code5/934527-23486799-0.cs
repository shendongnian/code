    private class Part
    {
        public string Id { get; set; }
        public string Class { get; set; }
    
        // When overide Equals
        // You have to override this method too
        public override int GetHashCode() {
          return String.IsNullOrEmpty(Id) ? 0 : Id.GetHashCode();
        }
    
        public override bool Equals(object obj)
        {
            Part part = obj as Part;
    
            return this.Id == part.Id;
        }
    }
