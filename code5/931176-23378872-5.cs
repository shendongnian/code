    public static void DivideandInsert(List<Node> list)
        {
            List<List<Node>> smallList = new List<List<Node>>();
             //an extra list
            List<Node> filtered_list = new List<Node>(); 
    
    //This part will get you all the 55 nodes with density > 5
    foreach(Node n in list) 
    {
     if(n.Density > 5)
    {
     filtered_list.Add(n);
    }
    }
    
    int i = j = 0;
              // For all those 55 nodes insert
            foreach (Node nn in filtered_list)
            {
    //insert first 10 to smallList[0]
                   if (i < 10) 
                    {
                        smallList[j].Add(nn);
                        i++;
                    }
    
                   //once 10 node insertion is over
                    if(i >= 10) 
                    {
                      //reset i to 0 to start over again 
                      i = 0; 
               //<-- increment j so that next insertion will happen @smallList[1]
                      j++;                      
                    }
                }
        }
