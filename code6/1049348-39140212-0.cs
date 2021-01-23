    [Serializable()]
    public class Bar
    {
        private string m_Name;
        [DisplayName("Name")]
        [Description("The Name of Bar")]
        public string Name
        {
            get { return m_Name; }
        }
        public override string ToString()
        {
            return "Name you want to display";
        }
    }
