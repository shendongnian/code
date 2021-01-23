       static void Main(string[] args)
        {
            string[] a = File.ReadAllLines(@"C:/imp.txt");// to read all lines
            Console.WriteLine("enter a name whose password  u want to change");
            string g=Console.ReadLine();
            Console.WriteLine("enter new password");
            string j = Console.ReadLine();
            for(int i=0;i<a.Length;i++)                  
            {
                
                string[] h = a[i].Split(',');
                if(h[0]==g)
                {
                    a[i] = h[0] + ","+j+"," + h[2];
                    break;// after finding a specific name,you dont need to search more 
                }
            }
           
            File.WriteAllLines(@"C:/imp.txt",a);//to write all data from " a "  into file
            
        }
