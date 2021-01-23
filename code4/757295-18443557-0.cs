    class ItemEuqalityComprer : IEqualityComparer<Item>
    {
        public bool Equals(Item x, Item y)
        {
            return x.DrugCode1 == y.DrugCode2
                   && x.DrugCode2 == y.DrugCode1;
        }
        public int GetHashCode(Item obj)
        {
            return obj.Id == null ? 0 : obj.Id.GetHashCode();
        }
    }
