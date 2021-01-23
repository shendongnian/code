    public class MyClass 
    {
        Dictionary<uint, Dictionary<uint, Int64>> PartDict;
        Int64 ReadValue(uint id1, uint id2)
        {
            return (PartDict[id1])[id2];
        }
        void AddValue(uint id1, uint id2, Int64 value)
        {
            Dictionary<uint, Int64> container;
            if (!PartDict.TryGetValue(id1, out container))
            {
                container = new Dictionary<uint, Int64>();
                PartDict.Add(id1, container);
            }
            container.Add(id2, value);
        }
    }
