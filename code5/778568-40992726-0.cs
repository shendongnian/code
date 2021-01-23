        public override bool Equals(object obj)
        {
            return Country == (obj as ExampleEntity)?.Country;
        }
        public override int GetHashCode()
        {
            return this.Country.GetHashCode();
        }
