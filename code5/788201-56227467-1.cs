    private static void Serializer_UnknownElement(object sender, XmlElementEventArgs e)
    {
        if (e.ObjectBeingDeserialized is Article article)
        {
            if (e.Element.Name == "title")
            {
                article.Title_Custom = e.Element.InnerXml;
                return;
            }
        }
    }
