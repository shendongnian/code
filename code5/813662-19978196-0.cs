        [XmlArray("dependencies"), XmlArrayItem("dependency")]
        public List<string> Dependencies { get; set; }
        public bool ShouldSerializeDependencies()
        {
            if (Dependencies != null && Dependencies.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
