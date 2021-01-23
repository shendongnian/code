    [DefaultProperty("Text")]
    [ToolboxData("<{0}:WebControlExample runat=server></{0}:WebControlExample>")]
    public class WebControlExample: WebControl, INamingContainer
    {
        private readonly int[] goodies = new int[48];
        private readonly int[] goodiesSpecial = new int[24];
    
        private bool isSpecial= false;
        public bool IsSpecial
        {
            set
            {
                this.isSpecial= value;
            }
        }
    
        private int[] Goodies
        {
             get {return isSpecial ? goodiesSpecial : goodies;}
        }
    }
