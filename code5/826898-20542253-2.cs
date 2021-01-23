    namespace ExampleNamespace
    {
        [MetadataType(typeof(ScheduleMetaData))]
        public partial class Schedule
        {
    
        }
    
        public class ScheduleMetaData
        {
            [RegularExpression(@"^#(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$", ErrorMessage = "Invalid hex color")]
            [Required]
            public string Color { get; set; }
        } 
    }
