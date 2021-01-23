    List<string> listOfXML = new List<string>()
    			{
    			   @"<Element>  
      <FirstAttribute>A</FirstAttribute>> 
      <SecondAttribute>B</SecondAttribute> 
      <ThirdAttribute>3</ThirdAttribute> 
    </Element>",
    		   @"<Element>  
       <FirstAttribute>C</FirstAttribute>> 
       <SecondAttribute>D</SecondAttribute> 
       <ThirdAttribute>4</ThirdAttribute> 
    </Element>",
    		   @"<Element>  
       <FirstAttribute>A</FirstAttribute>> 
       <SecondAttribute>B</SecondAttribute> 
       <ThirdAttribute>1</ThirdAttribute> 
    </Element>"
    			};
    
    List<string> order = new List<string>();
    int[] orders = new int[listOfXML.Count];
    
    int arraylength = orders.Length;
    
    for (int i = 0; i < arraylength; i++)
    {
        orders[i] = Convert.ToInt32(XElement.Parse(listOfXML[i]).Element("ThirdAttribute").Value);
    }
    Array.Sort(orders);
    
    for (int i = 0; i < arraylength; i++)
    {
        string orderedXMLString = GetXmlString(orders[i], listOfXML);
        order.Add(orderedXMLString);
    }
    
     private static string GetXmlString(int p, List<string> listOfXML)
    {
        string retXML = string.Empty;
        foreach (var item in listOfXML)
        {
            if (p == Convert.ToInt32(XElement.Parse(item).Element("ThirdAttribute").Value))
            {
                retXML = item;
            }
        }
        return retXML;
    }
