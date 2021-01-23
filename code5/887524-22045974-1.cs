    public class Employee
    {
        [Required(ErrorMessage = "* required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "* required")]
        public string EmployeeString { get; set; }
        ...
    }
    [MetadataType(typeof(EmployeeEntitiesMetadata))]
    public partial class Employee
    {
    }
