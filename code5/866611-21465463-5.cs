    public class View
    {
        public int Id { get; set; }
        public int ViewerId { get; set; }
        [ForeignKey("ViewerId")] // here is a foreignkey property
        [InverseProperty("Viewers")] // here is a navigation property in Person class
        public Person Viewer { get; set; }
    }
