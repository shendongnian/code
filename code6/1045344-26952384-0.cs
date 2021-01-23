    class Assembly:IComparable
    {
        public int Level { get; set; }
        public string Parent { get; set; }
        public string Component { get; set; }
        public int CompareTo(object obj)
        {
            var other = obj as Assembly;
            if (this.Level != other.Level)
            {
                return this.Level.CompareTo(other.Level);
            }
            if (this.Parent != other.Parent)
            {
                return this.Parent.CompareTo(other.Parent);
            }
            return this.Component.CompareTo(other.Component);
        }
    }
