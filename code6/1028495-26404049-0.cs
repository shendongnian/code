    //I've had a stab in the dark at your assembly name
    //the bit after the comma could be wrong
    string namespaceName = "GlobalLib.Toolkits.XmlService.Main, GlobalLib.Toolkits";
            
    Type CAType = Type.GetType(namespaceName);
    var myObj = Activator.CreateInstance(CAType);
    Form nextForm2 = (Form)myObj;
