    public static void Main(string[] args)
    {              
        int [] array =new int[]{10, 5, 10, 2, 2, 3, 4, 5, 5, 6, 7, 8, 9, 11, 12, 12};
        Array.Sort(array);
        for (int i = 0; i < array.Length; i++)
        {
            int count = 1,k=-1;
            for (int j = i+1; j < array.Length; j++)
            {  
              
                    if(array[i] == array[j])
                    {
                        count++;
                        k=j-1;
                    }
                    else break;
            }
            Console.WriteLine("\t\n " + array[i] + "---------->" + count);            
            if(k!=-1)
                i=k+1;          
        }
    }
