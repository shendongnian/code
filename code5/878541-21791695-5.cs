    private static void Main(string[] args)
        {
            string line;
            double[,] a = new double[89359, 100];
            StreamReader file = new StreamReader("c:\\joao.txt");
            for (int x = 1; x <= 8935900; x++)
            {
                line = file.ReadLine();
                string[] values = line.Split(' ');
                int i, j;
                foreach (string value in values)
                {
                    i = Convert.ToInt32(values[0]);
                    j = Convert.ToInt32(values[1]);
                    a[i, j] = Convert.ToDouble(values[2]);
                }
            }
            var allValues = a.OfType<double>();
            using (var filestream = new FileStream("1000.txt", FileMode.Create))
            using (var streamwriter = new StreamWriter(filestream))
            {
                foreach (double value in allValues)
                    streamwriter.WriteLine(value);
            }
        }
 
