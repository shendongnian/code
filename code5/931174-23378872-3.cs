    public static void DivideandInsert(List<Node> list)
        {
            List<List<Node>> smallList = new List<List<Node>>();
    
            List<Node> filtered_list = new List<Node>(); <-- an extra list
    
    foreach(Node n in list) <-- This part will get you all the 55 nodes with density > 5
    {
     if(n.Density > 5)
    {
     filtered_list.Add(n);
    }
    }
    
    int i = j = 0;
    
            foreach (Node nn in filtered_list) <-- For all those 55 nodes insert
            {
                   if (smallList[j].Count < 10) <-- insert first 10 to smallList[0]
                    {
                        smallList[j].Add(nn);
                        i++;
                    }
    
                    if(i >= 10) <-- once 10 node insertion is over
                    {
                      i = 0; <-- reset i to 0 to start over again
                      j++;  <-- increment j so that next insertion will happen @smallList[1] 
                    }
                }
        }
