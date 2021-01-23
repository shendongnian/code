    bool IsMoreXml = true;
    while (IsMoreXml)
    {
        var ValuesRead = null; //not sure what you're reading
        try
        {
            IsMoreXml = reader.Read();
            if(!IsMoreXml) break;
            //Do Stuff
            ValuesRead = whateverwereadfromxml;
        }
        catch (XmlException ex)
        {
            //do what you gotta do
            break;
        }
        if(ValuesRead != null)
            yield return ValuesRead;
    }
