        public static void RemoveEmptyElementsAndWhiteSpaces(this XDocument document)
        {
            if(null == document)
                throw new ArgumentNullException("document");
            document.Descendants()
                .Where(e => e.IsEmpty || string.IsNullOrWhiteSpace(e.Value))
                .Remove();
        }
