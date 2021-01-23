    public class Parent
            {
                public Parent()
                {
                    this.ListChild = new List<Child>();
                }
                public int ParentID { get; set; }
                public string ParentCode { get; set; }
                public List<Child> ListChild { get; set; }
            }
    
            public class Child
            {
                public int ChildID { get; set; }
                public string ChildCode { get; set; }
                public Parent Parent { get; set; }
            }
    
            public class ParentDTO
            {
                public ParentDTO()
                {
                    ListChild = new List<ChildDTO>();
                }
                public int ParentID { get; set; }
                public string ParentCode { get; set; }
                public List<ChildDTO> ListChild { get; set; }
            }
    
            public class ChildDTO
            {
                public int ChildID { get; set; }
                public string ChildCode { get; set; }
                public ParentDTO ParentDTO { get; set; }
            }
