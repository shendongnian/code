    public class Custom
    {
        int ID;
        List<String> listBuyItems;
       
       public string displayValue() 
       {
          string result = string.Empty;
          
         if(listBuyItems!= null)
         {
           foreach (var item in listBuyItems)
           {
                 result +=   "|" + item;      
           }
         }
           return result;
        }
    } 
