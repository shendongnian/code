    //Added to set up the sample
    var xml = "<root><CRQ><ID>CRQ000000003314</ID><Status>1</Status><Summary>complete</Summary><Service>Server</Service> <Impact>3000</Impact><Risk>2</Risk><Urgency>4000</Urgency><Class>4000</Class><Environment>1000</Environment><Trigger/><TriggerID>CP_00</TriggerID><Coordinator>user name</Coordinator><Desc>ticket description.</Desc></CRQ></root>";
    XElement root = XElement.Parse(xml);
    
    //Coded Solution
    var value = (from el in root.Elements("CRQ") where el.Element("ID").Value == "CRQ000000003314" select el).FirstOrDefault();
    
    //Testing output
    foreach(XElement el in value.Elements()){
        Console.WriteLine("Element Name: {0} = {1}",el.Name, el.Value);
    }
    
   
