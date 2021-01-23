    [AttributeUsage(AttributeTargets.Field)]
    public sealed class MapsToAttribute : Attribute
    {
        private string Text;
        public string MapsToText
        {
            get
            {
                return Text;
            }
        }
        public MapsToAttribute(string mapsToText)
        {
            Text = mapsToText;
        }
        public override string ToString()
        {
            return Text;
        }
    }
