        private static XElement NewElement(Enum name, params object[] content)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            return new XElement(name.ToString(), content);
        }
