    public string FruitName
    {
       get
       {
           switch(someOtherField)
           {
               default:
               case 1:
                 return "Apple";
               case 2:
                 return "Orange";
               // ... 
           }
       }
    }
