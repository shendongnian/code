    public class Photo
    {
        public string Src { get; set; }
        public string Alt { get; set; }
    
        public string ToHtml()
        {
            return string.Format(
                "<img src='{0}' alt='{1}'/>,
                this.Src,
                this.Alt);
        }
    }
