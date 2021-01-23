    static void Main(string[] args)
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        try
        {
            int value1 = 22;
            int value2 = 0;
            int result = client.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);
            client.Close();
        }
        catch (FaultException<MathFault> e)
        {
            Console.WriteLine("FaultException<MathFault>: Math fault while doing " + e.Detail.Operation + ". Problem: " + e.Detail.ProblemType);
            client.Abort();
            Console.ReadLine();
        }
    }
