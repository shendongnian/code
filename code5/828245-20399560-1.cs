    //Here   is a sample on  how you can achieve this  
 
     static void Main(string[] args)
        {
           //Two list [source , compare ]
        int[] ListSource = new int[]{ 4,8,12,20,24,32 } ;
        int[] ListToCompare = new int[] { 3, 8, 16, 16, 20, 24, 28, 32,36 };
            
            var res = ListToCompare.Except(ListSource);
            var NewListSource = ListSource.ToList();
            NewListSource.AddRange(res);
           ListSource = NewListSource.OrderBy(x=>x).ToArray();  
            //And finally my Listsou
        }
    }
    
   
