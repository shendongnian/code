        public EncodedHtmlString(string value)
        {
            this.encodedValue = HttpUtility.HtmlEncode(value);
        }
        public NonEncodedHtmlString(string value)
        {
            this.value = value;
        }
