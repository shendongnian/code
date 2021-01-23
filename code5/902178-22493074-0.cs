    foreach (XElement element in doc.Descendants("groof"))
    {
    	string mmname = element.Attribute("NAME").Value.ToString();
    
        if (mmname == "GOBS-2")
        {
            bool found = false; 
            foreach (XElement element1 in element.Descendants("sintal"))
            {
    
                if (found == false)
                {
                    string CurrentValue = (string)element1;
                    if ("Cynthia1" == CurrentValue)
                    {
                        try
                        {
                            //do something
                            found = true;
                        }
                        catch (Exception e)
                        {
                        }
                    }
                }
            }
        }
    }
