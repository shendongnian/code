    public class ElementFactory
    {
        public DocxElement Resolve(string htmlTag)
        {
            var type = Type.GetType(string.Format("{0}.Docx{1}",
                typeof(ElementFactory).Namespace,
                CultureInfo.CurrentCulture.TextInfo.ToTitleCase(htmlTag)));
            return (DocxElement)Activator.CreateInstance(type);
        }
    }
