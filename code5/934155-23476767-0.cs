    class A {
        public string Message { get; set; }
    }
    public static void Main()
    {
        A mainData = new A();
        mainData.Message = "Main Data Message";
        A backupData = mainData;
        backupData.Message = "Backup Data Message";
        
        Console.WriteLine(mainData.Message);
        // Prints Backup Data Message
        Console.WriteLine(backupData.Message);
        // Prints Backup Data Message
    }
