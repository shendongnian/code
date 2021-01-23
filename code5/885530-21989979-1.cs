    public class Incident : IComparable<Incident>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string IncidentType { get; set; }
        
        public int CompareTo(Incident other)
        {
            string str = other.Description;
            int ret = String.Compare(str, Description, StringComparison.OrdinalIgnoreCase);
            if (ret != 0)
                return ret;
            str = other.IncidentType;
            ret = String.Compare(str, IncidentType, StringComparison.OrdinalIgnoreCase);
            return ret;
        }
    }
