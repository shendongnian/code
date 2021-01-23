        public string CopyWPFControl<T>(T source)
        {
            string childXaml = XamlWriter.Save(source);
            var stringReader = new StringReader(childXaml);
            return stringReader.ToString();
        }
