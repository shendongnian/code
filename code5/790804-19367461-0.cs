    if (xr.NodeType == XmlNodeType.Element)
    {
        element = xr.Name;
    }
    else if (xr.NodeType == XmlNodeType.Text)
    {
        if (element == "nc:PersonFullName")
        {
            attyName = xr.Value;
        }
        else if (element == "nc:IdentificationID")
        {
            elementCount++;
            DocID = xr.Value;
            if (elementCount == 1)
            {
                reqID = DocID;
            }
    
            if (elementCount == 3)
            {
                empName = DocID;
            }
    
            if (elementCount == 8)
            {
                attyBarID = DocID;
    
                elementCount = 0;
                break;
            }
        }
        else if (element == "nc:CaseTrackingID")
        {
            elementCount++;
            DocID = xr.Value;
            if (elementCount == 1)
            {
                reqID = DocID;
            }
    
            if (elementCount == 3)
            {
                empName = DocID;
            }
    
            if (elementCount == 8)
            {
                attyBarID = DocID;
    
                elementCount = 0;
                break;
            }
        }
    }
