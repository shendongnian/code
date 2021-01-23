    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            Document doc = new Document();
            Console.ReadLine();
            doc.AssignCase(123456);
            Console.ReadLine();
            doc.SubmitTo("clientAddress");
            
            Console.ReadLine();
            doc.Acknowledged("responseFromClient");
            Console.ReadLine();
            const int TERMS_REJECTED = 123;
            doc.Complete(TERMS_REJECTED);
            Console.ReadLine();
        }
    }
