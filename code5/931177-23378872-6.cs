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
      int count  = filtered_list.Count;
      int sublist_count  = (count % 10 == 0) ? count / 10 : count / 10 + 1;
           for(int i=0;i<sublist_count;i++)
            {
                    List<int> sublist = new List<int>();
                    for (int k = 0; k < 10; k++)
                    {
                        sublist.Add(filtered_list[k]);
                    }
                smallList.Add(sublist);
            }   
      }
