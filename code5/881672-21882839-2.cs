        public T RecreateWPFControl<T>(string source)
        {
            var xmlReader = XmlReader.Create(source);
            var clonedChild = (T)XamlReader.Load(xmlReader);
            return clonedChild;
        }
