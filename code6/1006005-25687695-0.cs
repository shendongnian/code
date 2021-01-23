    public class ReportByProjectModel
    {
            public string projectID { get; set; }
            public int month { get; set; }
            public int year { get; set; }
            public string type { get; set; }
    
        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }
    
            // If parameter is the wrong type then return false.
            ReportByProjectModel p = obj as TwoDPoint;
            if (p == null)
            {
                return false;
            }
    
            // Return true if the fields match:
            return obj.projectID  == p.projectID
               && obj.month == p.month 
               && obj.year == p.year
               && obj.type == p.type;
        }
    
        public override int GetHashCode()
        {
            return string.Concat(projectID, "|", month, "|", year "|", type).GetHashCode();
        }
    }
