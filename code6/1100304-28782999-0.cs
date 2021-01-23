    [Serializable]
    public class Settings
    {
        internal static XmlSerializer Serializer = new XmlSerializer(typeof(Settings));
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlElement("Difficulty")]
        public string XmlDifficulty
        {
            get
            {
                return Difficulty.ToString();
            }
            set
            {
                try
                {
                    Difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), value);
                }
                catch
                {
                    Debug.WriteLine("Invalid difficulty found: " + value);
                    Difficulty = Difficulty.Normal;
                }
            }
        }
        [XmlIgnore]
        public Difficulty Difficulty { get; set; }
        public Boolean CaptureMouse { get; set; }
        internal void loadDefaults()
        {
            this.Difficulty = Difficulty.Normal;
            this.CaptureMouse = false;
        }
    }
