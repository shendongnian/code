    var slot = xml.Descendants("Slot")
                  .Where(n => n.Attribute("name").Value == "sourcePatientInfo")
                  .FirstOrDefault();
    if(slot == null)                  
    {
        throw new WhateverAppropriateHereEcxeption();
    }
    var values = slot.Descendants("Value").ToList();
    if(values.Count < 2)                  
    {
        throw new WhateverAppropriateHereEcxeption();
    }
    values[0].Value = "PID-3|MyPID"  // updating the first value
    values[1].Value = "PID-5|MyName" // updating the second value
