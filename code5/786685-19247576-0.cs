    while (xr.Read())
    {
        if (xr.NodeType == XmlNodeType.Element)
        {
            element = xr.Name;
            if (element == "source")
            {
                sourceKey = xr.GetAttribute("key");
            }
        }
        else if (xr.NodeType == XmlNodeType.Text)
        {
            if (element == "value")
            {
                sourceValue = xr.Value;
            }
        }
        else if (sourceValue != "" && (xr.NodeType == XmlNodeType.EndElement) && (xr.Name == "source"))
        {
            // there is problem
            messageBox += sourceKey + " " + sourceValue + "\n";
            sourceValue = "";
        }
    }
