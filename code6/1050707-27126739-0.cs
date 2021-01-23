    class Category  {
        public override bool Equals(object obj)
        {
            if (!(obj is Category)) return false;
            return this.CategoryName == ((Category)obj).CategoryName;
        }
        public override int GetHashCode()
        {
            this.CategoryName.GetHashCodeU();
        }
    }
