    public class SavedSettings
    {
        [XmlIgnore]
        public Color ForeColor { get; set; }
    
        [XmlElement("ForeColor")]
        public int ForeColorARGB
        {
          get { return this.ForeColor.ToArgb(); }
          set { this.ForeColor = Color.FromArgb(value); }
        }
        [XmlIgnore]
        public Color BackColor { get; set; }
        [XmlElement("BackColor")]
        public int BackColorARGB
        {
          get { return this.BackColor.ToArgb(); }
          set { this.BackColor = Color.FromArgb(value); }
        }
        public object Value { get; set; }
    }
