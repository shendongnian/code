    class Program
    {
        static void Main(string[] args)
        {
            aclass a = new aclass();
            Process(ref a);
            Console.WriteLine(a.number);
    
            Console.ReadLine();
        }
    
        static void Process(ref aclass a)
        {
            aclass temp = new aclass();
            temp.number++;
            //Console.WriteLine(temp.number);
    
            a = temp;
            a.number++;
            //Console.WriteLine(a.number);
        }
    
    }
