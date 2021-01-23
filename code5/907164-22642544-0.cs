    public string myMethod(int hours)
    {
        return string.Format("{0:+#;-#}:00", hours);
    }
    
    Console.WriteLine(myMethod(1));   // +1:00
    Console.WriteLine(myMethod(-2));  // -2:00
    Console.WriteLine(myMethod(12));  // +12:00
