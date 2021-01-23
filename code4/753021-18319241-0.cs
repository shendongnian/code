    foreach (XElement step in document.Descendants("Step"))
    {
        // Start looping through that step's checks
        foreach (XElement substep in step.Elements())
        {
            Console.WriteLine(step.Attribute("Name").Value + "" 
                            + substep.Attribute("Name").Value);
        }
    }
