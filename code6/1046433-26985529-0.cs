    public class TreeViewModel
    {
        public string Text { get; set; }
        public string Cls { get; set; }
        public bool Expanded { get; set; }
        [JsonProperty(PropertyName = "checked")]
        public bool Checked { get; set; }
        public bool Leaf { get; set; }
        public List<TreeViewModel> Children { get; set; }
        public bool ShouldSerializeCls()
        {
            return Children != null && Children.Count > 0;
        }
        public bool ShouldSerializeExpanded()
        {
            return Children != null && Children.Count > 0;
        }
        public bool ShouldSerializeChildren()
        {
            return Children != null && Children.Count > 0;
        }
    }
