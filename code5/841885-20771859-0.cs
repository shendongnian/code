    static void Main(string[] args) {
      Console.WriteLine("Enter text to be reversed");
      string inputText = Console.ReadLine();
    
      // Backward loop
      for (int i = inputText.Length - 1; i >= 0; --i)
        Console.Write(inputText[i]);
    }
