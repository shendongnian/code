    private class Line
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string Period { get; set; }
        public string Bytes { get; set; }
        public string User { get; set; }
        public string Filename { get; set; }
        public override string ToString()
        {
            // Just an example, you could create an other implementation
            return string.Format("Filename: {0} -  Date: {1}", Filename, Date);
        }
    }
