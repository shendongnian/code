    private class Part
    {
        public string Id { get; set; }
        public string Class { get; set; }
    
        // Whenever overiding Equals
        // You have to override this method too
        public override int GetHashCode() {
          return String.IsNullOrEmpty(Id) ? 0 : Id.GetHashCode();
        }
    
        public override bool Equals(object obj)
        {
            Part part = obj as Part;
    
            // if obj is not of Part you should return false
            if (Object.ReferenceEquals(null, part))
              return false; 
            return this.Id == part.Id;
        }
    }
