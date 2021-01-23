    public partial class ObjectiveDetail
    {
        public ObjectiveDetail()
        {
            this.SubTopics = new List<SubTopic>();
        }
        public int ObjectiveDetailId { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
        public virtual ICollection<SubTopic> SubTopics { get; set; }
        public override bool Equals(Object obj)
        {
            var typedObj = obj as ObjectiveDetail;
            return Equals(typedObj);
        }
        public bool Equals(ObjectiveDetail obj)
        {
            if ((object)obj == null) return false;
            return ObjectiveDetailId == obj.ObjectiveDetailId &&
                   Number == obj.Number &&
                   Text == obj.Text &&
                   SubTopics != null && obj.SubTopics != null && // Just in the unlikely case the list is set to null
                   SubTopics.Count == obj.SubTopics.Count;
        }
        public override int GetHashCode()
        {
            return new { A = ObjectiveDetailId, B = Number, C = Text }.GetHashCode();
        }
    }
