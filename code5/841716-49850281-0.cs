     class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 10, 20,20, 30, 10, 50 ,50,9};
            List<int> listadd = new List<int>();
            
            for (int i=0; i <arr.Length;i++)
            {
               int count = 0;
                int flag = 0;
                for(int j=0; j < arr.Length; j++)
                {
                    if (listadd.Contains(arr[i]) == false)
                    {
                        
                        if (arr[i] == arr[j])
                        {
                            count++;
                        }
                       
                    } 
                    else
                    {
                        flag = 1;
                    }
                    
                }
                listadd.Add(arr[i]);
                if(flag!=1)
                Console.WriteLine("No of occurance {0} \t{1}", arr[i], count);
            }
            Console.ReadLine();
        }
    }
