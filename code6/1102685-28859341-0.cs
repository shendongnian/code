    private Image GetImage(XElement element)
    {
        var image = new Image();
    
        XElement imageElement = element.Element("img");    
        if (imageElement != null)
        {
            image.Url = (String)imageElement.Attribute("src");
        }
        return image;
    }
