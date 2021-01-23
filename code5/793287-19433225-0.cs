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
            //This was the base template's implementation:
            //encodedString = TemplateService.EncodedStringFactory.CreateEncodedString(value);
            //_context.CurrentWriter.Write(encodedString);
            //replaced with:
            writer.Write(value.ToString());
        }
    }
