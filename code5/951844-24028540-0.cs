    public class Property
    {
        public IEnumerable<Part> MainParts
        {
            get
            {
                return Parts.Where(i => i.PartType == PartType.Main);
            }
        }
    }
