    public class Program
    {
        public static string ReadFile(string filename)
        {
            //A BCL method that throws various exceptions
            return System.IO.File.ReadAllText(filename);
        }
        public static void Main(string[] args)
        {
            try
            {
                Console.Write(ReadFile("name.txt"));
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured when retrieving the name! {0}", e.Message);
            }
            try
            {
                Console.Write(ReadFile("age.txt"));
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured when retrieving the age! {0}", e.Message);
            }
        }
    }
