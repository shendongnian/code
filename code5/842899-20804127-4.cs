    sealed class UnitManager
    {
        static readonly UnitManager instance = new UnitManager();
        public static UnitManager Instance { get { return instance; } }
        Dictionary<string, int> unitCostDictionary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase); // Ignore Case of Keys
        public int LookupUnitCost(string unitType)
        {
            int unitCost = 0;
            unitCostDictionary.TryGetValue(unitType, out unitCost);
            return unitCost;
        }
    }
