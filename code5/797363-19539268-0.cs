    public class Project
    {
        public int ProjectID { get; set; }
    
        public override bool Equals(object obj)
        {
            var p2 = obj as Project;
            if (p2 == null) return false;
            return this.ProjectID == m2.ProjectID;
        }
    
        public override int GetHashCode()
        {
            return ProjectID;
        }
    }
