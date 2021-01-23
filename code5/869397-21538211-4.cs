    class Candy : IThing, IInspectable
    {
        public IEnumerable<IInspectable> GetStuffForInspection()
        {
            if (IsWrapped && IsHard)
                yield return this;
        }
        public String Value { ... }
        public void Taste() { ... }
    }
    class Chocolate : Sweet, IThing
    {
        public IEnumerable<IInspectable> GetStuffForInspection()
        {
            Calories.Where(c => !c.IsGood);
        }
    }
    class Calorie : IInspectable
    {
        public String Value { ... }
        public void Taste() { ... }
    }
