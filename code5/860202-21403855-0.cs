    public class ObjectiveDetail 
    {
        public ObjectiveDetail() {
            this.SubTopics = new HashSet<SubTopic>();
        }
        public int ObjectiveDetailId { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
        public virtual ICollection<SubTopic> SubTopics { get; set; }
    }
    public partial class SubTopic 
    {
        public SubTopic() {
            this.ObjectiveDetail = new HashSet<ObjectiveDetail>();
        }
        public int SubTopicId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ObjectiveDetail> ObjectiveDetails { get; set; }
    }
