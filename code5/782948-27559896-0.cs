        static void Main(string[] args)
        {
            int[] rollno = new int[10];
            Console.WriteLine("Enter the 10 numbers");
            for (int s = 0; s < 9; s++)
            {
                rollno[s] = Convert.ToInt32(Console.ReadLine());
                rollno[s] +=  110;
            }
            for (int j = 0; j < 9; j++)
            {
                Console.WriteLine("The sum of first 10 numbers is : {0}", rollno[j]);
            }
            Console.ReadLine();
        }
    }
}
