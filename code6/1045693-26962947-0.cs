    public struct NameAndAmount
    {
        public string Name;
        public int Amount;
        public NameAndAmount(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
    }
    List<NameAndAmount> items = new List<NameAndAmount>();
    items.Add(new NameAndAmount("test", 100));
