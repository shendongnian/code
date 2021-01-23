    public class TrackingObject
    {
        public int OrderId { get; set; }
        public int ProjectCount { get; set; }
        public IList<ProjectInfo> Projects { get; set; }
        public TrackingObject() {
            this.Projects = new List<ProjectInfo>();
        }
        //This constructor optional, but since you're using an IList, may as well
        //let the user pass in an IList of a different type if they chose
        public TrackingObject(IList<ProjectInfo> defaultList) {
            this.Projects = defaultList;
        }
    }
