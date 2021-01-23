        public static void Main(string[] args)
        {
            double[][] JaggedOne = {
                                        new double[] { -5, -2, -1 },
                                        new double[] { -5, -5, -6 },
                                   };
            double[][] JaggedTwo = {
                                        new double[] {1, 2, -1 },
                                        new double[] { 4, 5, 6 },
                                   };
            double[][] result = JaggedOne.Union(JaggedTwo).ToArray();           
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    Console.Write(result[i][j]);
                }
                Console.WriteLine();
            }            
            Console.ReadKey();
        }
}    
