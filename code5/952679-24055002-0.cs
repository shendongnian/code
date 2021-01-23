    namespace MPP_TCP_Client // This should now be the same as the Cashier class
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Press enter to start client");
                Console.ReadKey();
                TcpClient whatever = Cashier.Connect(); // Cashier is not being seen by Visual     Studio
            }
        }
    }
