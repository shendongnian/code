     [MetadataType(typeof(StudentMetadata))]
        public partial class Student
        {
            [Display(Name = "Full Name")]
            public string FullName
            {
                get
                {
                    return LastName + ", " + FirstName;
                }
            }
        }
