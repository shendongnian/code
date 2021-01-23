    public string myMethod(int hours)
    {
        return string.Format("{0:+#;-#;+0}:00", hours);
    }
    Console.WriteLine(myMethod(0));   // +0:00
