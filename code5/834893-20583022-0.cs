       static void Main(string[] args)
        {
            String str = "Hello World";
            String[] strNames = str.Split(' ');
            for(int i=strNames.Length-1;i>=0;i--)
            Console.Write(strNames[i]+" ");
        }
