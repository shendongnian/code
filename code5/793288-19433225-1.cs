    public override void WriteTo(TextWriter writer, object value)
    {
        if (writer == null)
            throw new ArgumentNullException("writer");
        if (value == null) return;
        var encodedString = value as IEncodedString;
        if (encodedString != null)
        {
            writer.Write(encodedString);
        }
        else
        {
            var htmlString = value as IHtmlString;
            if(htmlString != null) 
                writer.Write(htmlString.ToHtmlString());
            else
            {
                //This was the base template's implementation:
                encodedString = TemplateService.EncodedStringFactory.CreateEncodedString(value);
                writer.Write(encodedString);
            }
        }
    }
