    public class Program
    {
        public static bool TryReadFile(string filename, out string val)
        {
            try 
            {
                val = System.IO.File.ReadAllText(filename);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static void Main(string[] args)
        {
            string name, age;
            Console.WriteLine(TryReadFile("name.txt", out name) ? name : "An error occured when retrieving the name!");
            Console.WriteLine(TryReadFile("age.txt", out age) ? age: "An error occured when retrieving the age!");
        }
    }
