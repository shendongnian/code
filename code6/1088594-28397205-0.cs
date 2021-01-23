         public Vector2[] directions=new Vector2[4];// put your vectors here
      
     
         void Sort() 
         {
          Array.Sort(directions, Vector2Compare);    
         }
    
    
         private int Vector2Compare(Vector2 value1, Vector2 value2)
         {
             // NOTE: THESE DEPENDS ON HOW YOU EVALUATE TOP/LEFT/RIGHT/BOTTOM , X and Y  
             if (value1.x < value2.x)
             {
                 return -1;
             }
             else if(value1.x == value2.x)
             {
                 if(value1.y < value2.y)
                 {
                     return -1;
                 }
                 else if(value1.y == value2.y)
                 {
                     return 0;
                 }
                 else
                 {
                     return 1;
                 }
             }
             else
             {
                 return 1;
             }
         }
