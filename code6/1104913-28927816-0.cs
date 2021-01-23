    class ToDoElement
    {
        public int id;
        public string title;
        public string description;
        public string tags
        {
            get
            {
                if (TagList == null)
                    return null;
                return string.Join(", ", TagList.ToArray());
            }
            set
            {
                if (value == null)
                {
                    TagList = null;
                    return;
                }
                TagList = value.Split(',').Select(s => s.Trim()).ToList();
            }
        }
        [ScriptIgnore]
        public List<string> TagList { get; set; }
    }
