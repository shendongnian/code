    public string GetElementAttributes(GeckoElement element)
    {
       var result = new StringBuilder();
       foreach(var a in element.Attributes)
       {
           result.Append(String.Format(" {0} = '{1}' ", a.NodeName, a.NodeValue));
       }
 
       return result.ToString();
    }
