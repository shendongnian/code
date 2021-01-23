        public T CopyWPFControl<T>(T source)
        {
            string childXaml = XamlWriter.Save(source);
            var stringReader = new StringReader(childXaml);
            var xmlReader = XmlReader.Create(stringReader);
            var clonedChild = (T)XamlReader.Load(xmlReader);
            return clonedChild;
        }
