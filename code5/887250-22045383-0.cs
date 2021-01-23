    public static void RemoveCustomer(XElement customers, XElement removeThis){
    
       var last = customeers.Elements().Last();
       if(last != removeThis){
           foreach(var element in removeThis.Elements()){
                element.Value = last.Element(element.Name).Value;
           }
       }
       last.Remove();
    }
