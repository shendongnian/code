    public class RollCollection : IEnumerable<Roll>
    {
        private List<Roll> _rolls = new List<Roll>();
        public RollCollection()
        {
            // We need to provide a default constructor if we want to be able
            // to instantiate an empty RollCollection and then add rolls later on
        }
        public RollCollection(IEnumerable<Roll> rolls)
        {
            // By providing a constructor overload which accepts an IEnumerable<Roll>,
            // we have the opportunity to create a new RollCollection based on a filtered existing collection of rolls
            _rolls = rolls.ToList();
        }
        public RollCollection WhichContainIngredients(IEnumerable<Ingredient> ingredients)
        {
            IEnumerable<Roll> filteredRolls = _rolls
                .Where(r => r.ContainsIngredients(ingredients));
            return new RollCollection(filteredRolls);
        }
        public bool AddRoll(Roll roll)
        {
            // Similar to AddIngredient
            bool alreadyContainsRoll = _rolls.Any(r => r.Name == roll.Name);
            if (!alreadyContainsRoll)
            {
                _rolls.Add(roll);
                return true;
            }
            return false;
        }
        #region IEnumerable implementation
        public IEnumerator<Roll> GetEnumerator()
        {
            foreach (Roll roll in _rolls)
            {
                yield return roll;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
