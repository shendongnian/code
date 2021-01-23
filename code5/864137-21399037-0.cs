    public class EnumDescription : Attribute
    {
        public string Text { get; private set; }
        public EnumDescription(string text)
        {
            this.Text = text;
        }
    }
