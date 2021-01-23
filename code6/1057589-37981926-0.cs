    private string CanonicalizeDsig(string input)
    {
        XmlDocument doc = new XmlDocument();
        doc.PreserveWhitespace = false;
        try
        {
            doc.LoadXml(input);
            XmlDsigC14NTransform trans = new XmlDsigC14NTransform();
            trans.LoadInput(doc);
            String c14NInput = new StreamReader((Stream)trans.GetOutput(typeof(Stream))).ReadToEnd();
            return c14NInput;
        }
        catch (Exception ex)
        {
            return String.Empty;
        }
    }
