        [XmlIgnore]
        public Color BaseColour { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlElement("BaseColour")]
        public string XmlBaseColour
        {
            get
            {
                return ColorTranslator.ToHtml(BaseColour);
            }
            set
            {
                BaseColour = ColorTranslator.FromHtml(value);
            }
        }
