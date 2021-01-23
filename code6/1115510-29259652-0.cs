     static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
           
            for(int i=0; i<array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
     
            int n1 = array[0];
            int n2 = array[1];
            //...
            //...
            Console.WriteLine(n1);
            Console.WriteLine(n2);
            
        }
       
