    void Main()
    {
        var r = new Random();
    
        Enumerable.Range(1, 5).Select(idx => r.Next()).Dump("before save");
        var s = r.Save();
        Enumerable.Range(1, 5).Select(idx => r.Next()).Dump("after save");
        r = s.Restore();
        Enumerable.Range(1, 5).Select(idx => r.Next()).Dump("after restore");
    
        s.Dump();
    }
    
    public static class RandomExtensions
    {
        public static RandomState Save(this Random random)
        {
            var binaryFormatter = new BinaryFormatter();
            using (var temp = new MemoryStream())
            {
                binaryFormatter.Serialize(temp, random);
                return new RandomState(temp.ToArray());
            }
        }
    
        public static Random Restore(this RandomState state)
        {
            var binaryFormatter = new BinaryFormatter();
            using (var temp = new MemoryStream(state.State))
            {
                return (Random)binaryFormatter.Deserialize(temp);
            }
        }
    }
    
    public struct RandomState
    {
        public readonly byte[] State;
        public RandomState(byte[] state)
        {
            State = state;
        }
    }
