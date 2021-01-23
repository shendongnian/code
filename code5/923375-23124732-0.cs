             int counter = 0 ;
             foreach (string s in List)
             {
                   if (counter == 0) // this is the first element
                    {
                      string newString += s;
                    }
                   else if(counter == List.Count() - 1) // last item
                    {
                    newString += s + ", ";
                    }else{
                     // in between
                   }
                    counter++;
           }
