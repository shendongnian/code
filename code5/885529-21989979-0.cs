    public class Incident : IComparable<Incident>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string IncidentType { get; set; }
        
        public int CompareTo(Incident other)
        {
            string str = other.Description;
            int ret = -String.Compare(Description, str, StringComparison.OrdinalIgnoreCase);
            if (ret != 0)
                return ret;
            str = other.IncidentType;
            ret = -String.Compare(IncidentType, str, StringComparison.OrdinalIgnoreCase);
            return ret;
        }
    }
