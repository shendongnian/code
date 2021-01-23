    serializer.UnknownElement += (s, e) =>
    {
        if (e.Element.LocalName == "custom" && e.ObjectBeingDeserialized is Video)
        {
            Video video = (Video)e.ObjectBeingDeserialized;
            if (video.Custom == null)
            {
                video.Custom = new Dictionary<string, string>();
            }
            foreach (XmlElement element in e.Element.OfType<XmlElement>())
            {
                XmlText text = (XmlText)element.FirstChild;
                video.Custom.Add(element.LocalName, text.Value);
            }
        }
    };
