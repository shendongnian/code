        public override string ToString()
        {
            XmlSerializer s = new XmlSerializer(typeof(ABC));
            StringBuilder sb = new StringBuilder();
            var xtw = XmlTextWriter.Create(sb);
            s.Serialize
                (xtw, this);
            return sb.ToString();
    }
