    public class CameraDisplayMap {
        public int Id { get; set; } //primary key
        
        public int? SetupGroupId { get; set; }       //foreign key to [SetupGroup]
        public int? CameraId { get; set; }           //foreign key to [Camera]
        public int? DisplayId Displays { get; set; } //foreign key to [Display]
        
        public virtual SetupGroup SetupGroups { get; set; }
        public virtual Camera Cameras { get; set; }
        public virtual Display Displays { get; set; }
    }
