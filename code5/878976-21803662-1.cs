    public class ModelRegistrationModel
    {
        [Required]
        public int Id{ get; set; }
        [Required]
        [Remote("IsNameAlreadyInUse", "Validation", areaName: "AreaName")]
        public string Name { get; set; }
    }
