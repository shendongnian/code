    //...
              using (var reader = new StreamReader(stream))
              {
                while (reader.Peek() != -1) //use Peek instead
                {
                  using (var parser = new TextFieldParser(reader))
                  {
                    parser.HasFieldsEnclosedInQuotes = true;
                    parser.Delimiters = new string[] {","};
    
                    Console.WriteLine(parser.ReadLine().ToString());
                  }
                }
              }
    //...
