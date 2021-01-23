    [LayoutRenderer("truncate")]
    [ThreadAgnostic]
    public sealed class TruncateLayoutRendererWrapper : WrapperLayoutRendererBase
    {
        public TruncateLayoutRendererWrapper()
        {
            this.Truncate = true;
            this.Ellipsis = true;
            this.Limit = 1000;
        }
        [DefaultValue(true)]
        public bool Truncate { get; set; }
        [DefaultValue(true)]
        public bool Ellipsis { get; set; }
        [DefaultValue(1000)]
        public bool Limit { get; set; }
        /// <summary>
        /// Post-processes the rendered message. 
        /// </summary>
        /// <param name="text">The text to be post-processed.</param>
        /// <returns>Trimmed string.</returns>
        protected override string Transform(string text)
        {
            if (!Truncate || Limit <= 0) return text;
            var truncated = text.Substring(0, Ellipsis ? Limit - 3 : Limit);
            if (Ellipsis) truncated += "...";
            
            return truncated;
        }
    }
