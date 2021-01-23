        static void Main()
        {
    #ifdef DEBUG
            Application.Run();
    #else
            ServiceBase service = new SampleService(); 
            ServiceBase.Run(service); 
    #endif
        }
