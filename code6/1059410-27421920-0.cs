    public partial class Exam {
        public string ID { set; get; } //default
    
        public string Name { set; get; } //default
    
        public readonly Dictionary<string, object> ExtraProperties = new Dictionary<string, object>();
    }
