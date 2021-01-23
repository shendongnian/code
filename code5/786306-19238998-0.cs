    class Program {
        static void Main(string[] args) {
            try {
                try {
                    throw new Exception("You won't see this");
                }
                finally {
                    throw new Exception("You'll see this");
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
