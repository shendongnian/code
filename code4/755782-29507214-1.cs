           int a;
            Console.WriteLine("Enter the array length");
            a=int.Parse(Console.ReadLine());
            Console.WriteLine("enter the array element");
            int[] sau = new int[a];
            for (int i = 0; i < a; i++)
            {
                sau[i] = int.Parse(Console.ReadLine());
            }
            for (int i =a.Length-1 ; i < 0;i--)
            {
                Console.WriteLine(sau[i]);
            }
                Console.ReadLine();
        }
    }
}
