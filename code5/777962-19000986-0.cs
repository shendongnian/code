      public enum myResource
        {
            HelloWorld,
            ByeWorld
        }
 
    public string GetText(myResource someRes)
            {
                string sText = "";
                switch (someRes)
                {
                    case someRes.HelloWorld:
                        sText = "Hello World";
                        break;
                    case someRes.ByeWorld:
                        sText = "ByeWorld";
                        break;
                    default:
                        sText = "Empty...";
                        break;
                }
    
                return sText ;
    
            }
