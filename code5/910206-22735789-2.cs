    [Serializable]
    public class Building
    {
        public static Building Instance = new Building();
        public readonly Dictionary<string, Beam> Beams = new Dictionary<string, Beam>();
        public readonly Dictionary<string, Column> Columns = new Dictionary<string, Column>();
        public static Dictionary<string, Beam> AllBeams
        {
            get { return Instance.Beams; }
        }
    }
