                JintEngine engine = new JintEngine();
                engine.Run(ReadJavaScript());
                Console.WriteLine(engine.Run("reverse('Foooooo');"));
       public static  string ReadJavaScript()
       {
        string allines = File.ReadAllText(@"[path]\test.js");
       }
        
    public void Test1(string message)
    {
    MessageBox.show(message);
    }
