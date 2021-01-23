    public class IO
    {
        public static void write(string name)
        {
            try
            {
                string path = @"e:\mytxtfile.txt";
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(name);
                }	
            }
            catch (Exception ex)
            {
                Console.WriteLine("Issue in writing: " + ex.Message);
            }
        }
        public static void Main(string[] args)
        {
            string name;
            int ch;
            List<string> list = new List<string>();
            do
            {
                Console.WriteLine("Enter name");
                name = Console.ReadLine();
                write(name);
                Console.WriteLine("Enter 1 to continue");
                ch = Convert.ToInt32(Console.ReadLine());
            } while (ch == 1);
        }
    }
