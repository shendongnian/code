        [MetadataType(typeof(StudentMetadata))]
        public partial class Student
        {
        }
        public class StudentMetadata
        {
            [Display(Name = "Full Name")]
            public string FullName { get; set; }          
        } 
