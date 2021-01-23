    for(int i = 0; i < sList.Count; i++)
    {
         if(sList[i].getID == 1)
         {
              value = true;
              break; // exit the loop
         } 
         else if(sList[i].getID == 0)
         {
              value = false;
         }
    }
