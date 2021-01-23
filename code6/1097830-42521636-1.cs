    public class SimpleStateMachine
    {
      // 0 - outside - initial state
      // 1 - $ matched
      // 2 - ${ matched
      // 3 - } - final state
      // 0 -> 1 $
      // 0 -> 0 anything other than $
      // 1 -> 2 {
      // 1 -> 0 anything other than {
      // 2 -> 3 }
      // 2 -> 2 anything other than }
      // 3 -> 0
      public ITextReplacer TextReplacer { get; set; } = new DefaultTextReplacer();
      public int State { get; set; } = 0;
      public List<Text> TextsList { get;} = new List<Text>();
      public StringBuilder Buffer {get; } = new StringBuilder();
      /// <summary>
      /// The index inside the Text element where the $ is found
      /// </summary>
      public int Position { get; set; }
      public void Reset()
      {
        State = 0;
        TextsList.Clear();
        Buffer.Clear();
      }
      public void Add(Text text)
      {
        if (TextsList.Count == 0 || TextsList.Last() != text)
        {
          TextsList.Add(text);
        }
      }
      public void HandleText(Text text)
      {
        // Scan the characters
        for (int i = 0; i < text.Text.Length; i++)
        {
          char c = text.Text[i];
          switch (State)
          {
            case 0:
              if (c == '$')
              {
                State = 1;                
                Position = i;
                Add(text);
              }
              break;
            case 1:
              if (c == '{')
              {
                State = 2;                
                Add(text);
              }
              else
              {
                Reset();
              }
              break;
            case 2:
              if (c == '}')
              {
                Add(text);
                Console.WriteLine("Found: " + Buffer);
                // We are on the final State
                // I will use the first text in the stack and discard the others
                // Here I am going to distinguish between whether I have only one item or more
                if (TextsList.Count == 1)
                {
                  // Happy path - we have only one item - set the replacement value and then continue scanning
                  string prefix = TextsList[0].Text.Substring(0, Position) + TextReplacer.ReplaceValue(Buffer.ToString());
                  // Set the current index to point to the end of the prefix.The program will continue to with the next items
                  TextsList[0].Text = prefix + TextsList[0].Text.Substring(i + 1);
                  i = prefix.Length - 1;
                  Reset();
                }
                else
                {
                  // We have more than one item - discard the inbetweeners
                  for (int j = 1; j < TextsList.Count - 1; j++)
                  {
                    TextsList[j].Remove();
                  }
                  // I will set the value under the first Text item where the $ was found
                  TextsList[0].Text = TextsList[0].Text.Substring(0, Position) + TextReplacer.ReplaceValue(Buffer.ToString());
                  // Set the text for the current item to the remaining chars
                  text.Text = text.Text.Substring(i + 1);
                  i = -1;
                  Reset();
                }
              }
              else
              {
                Buffer.Append(c);
                Add(text);
              }
              break;
          }
        }
      }
    }
    private static void FillInValues(string sourceFileName, string destFileName)
    {
      File.Copy(sourceFileName, destFileName, true);
      using (WordprocessingDocument doc =
        WordprocessingDocument.Open(destFileName, true))
      {
        var body = doc.MainDocumentPart.Document.Body;
        var paras = body.Elements<Paragraph>();
        SimpleStateMachine stateMachine = new SimpleStateMachine();
        //stateMachine.TextReplacer = <your implementation object >
        foreach (var para in paras)
        {   
          foreach (var run in para.Elements<Run>())
          {
            //Console.WriteLine("New run:");
            var texts = run.Elements<Text>().ToArray();
            for (int k = 0; k < texts.Length; k++)
            {
              stateMachine.HandleText(texts[k]);             
            }
          }
        }
      }
    }
