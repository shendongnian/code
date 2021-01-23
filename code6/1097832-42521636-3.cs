    static void Main(string[] args)
    {
      //FillInValues(FileName("test01.docx"), FileName("test01_out.docx"));
      string[,] tests =
      {
        { "<r><t>${abc</t><t>}$</t><t>{tha}</t></r>", "<r><t>ABC</t><t>THA</t><t></t></r>"},
        { "<r><t>$</t><t>{</t><t>abc</t><t>}</t></r>", "<r><t>ABC</t><t></t></r>"},
        {"<r><t>${abc}</t></r>", "<r><t>ABC</t></r>" },
        {"<r><t>x${abc}</t></r>", "<r><t>xABC</t></r>" },
        {"<r><t>x${abc}y</t></r>", "<r><t>xABCy</t></r>" },
        {"<r><t>x${abc}${tha}z</t></r>", "<r><t>xABCTHAz</t></r>" },
        {"<r><t>x${abc}u${tha}z</t></r>", "<r><t>xABCuTHAz</t></r>" },
        {"<r><t>x${ab</t><t>c}u</t></r>", "<r><t>xABC</t><t>u</t></r>" },
        {"<r><t>x${ab</t><t>yupeekaiiei</t><t>c}u</t></r>", "<r><t>xABYUPEEKAIIEIC</t><t>u</t></r>" },
        {"<r><t>x${ab</t><t>yupeekaiiei</t><t>}</t></r>", "<r><t>xABYUPEEKAIIEI</t><t></t></r>" },
      };
      for (int i = 0; i < tests.GetLength(0); i++)
      {
        string value = tests[i, 0];
        string expectedValue = tests[i, 1];
        string actualValue = Test(value);
        Console.WriteLine($"{value} => {actualValue} == {expectedValue} = {actualValue == expectedValue}");
      }
      Console.WriteLine("Done!");
      Console.ReadLine();
    }
    public interface ITextReplacer
    {
      string ReplaceValue(string value);
    }
    public class DefaultTextReplacer : ITextReplacer
    {
      public string ReplaceValue(string value) { return $"{value.ToUpper()}"; }
    }
    public interface ITextElement
    {
      string Value { get; set; }
      void RemoveFromParent();
    }
    public class XElementWrapper : ITextElement
    {
      private XElement _element;
      public XElementWrapper(XElement element) { _element = element; }
      string ITextElement.Value
      {
        get { return _element.Value; }
        set { _element.Value = value; }
      }
      public XElement Element
      {
        get { return _element; }
        set { _element = value; }
      }
      public void RemoveFromParent()
      {
        _element.Remove();
      }
    }
    public class OpenXmlTextWrapper : ITextElement
    {
      private Text _text;
      public OpenXmlTextWrapper(Text text) { _text = text; }
      public string Value
      {
        get { return _text.Text; }
        set { _text.Text = value; }
      }
      public Text Text
      {
        get { return _text; }
        set { _text = value; }
      }
      public void RemoveFromParent() { _text.Remove(); }
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
              OpenXmlTextWrapper wrapper = new OpenXmlTextWrapper(texts[k]);
              stateMachine.HandleText(wrapper);
            }
          }
        }
      }
    }
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
      public List<ITextElement> TextsList { get; } = new List<ITextElement>();
      public StringBuilder Buffer { get; } = new StringBuilder();
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
      public void Add(ITextElement text)
      {
        if (TextsList.Count == 0 || TextsList.Last() != text)
        {
          TextsList.Add(text);
        }
      }
      public void HandleText(ITextElement text)
      {
        // Scan the characters
        for (int i = 0; i < text.Value.Length; i++)
        {
          char c = text.Value[i];
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
                  string prefix = TextsList[0].Value.Substring(0, Position) + TextReplacer.ReplaceValue(Buffer.ToString());
                  // Set the current index to point to the end of the prefix.The program will continue to with the next items
                  TextsList[0].Value = prefix + TextsList[0].Value.Substring(i + 1);
                  i = prefix.Length - 1;
                  Reset();
                }
                else
                {
                  // We have more than one item - discard the inbetweeners
                  for (int j = 1; j < TextsList.Count - 1; j++)
                  {
                    TextsList[j].RemoveFromParent();
                  }
                  // I will set the value under the first Text item where the $ was found
                  TextsList[0].Value = TextsList[0].Value.Substring(0, Position) + TextReplacer.ReplaceValue(Buffer.ToString());
                  // Set the text for the current item to the remaining chars
                  text.Value = text.Value.Substring(i + 1);
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
    public static string Test(string xml)
    {
      XElement root = XElement.Parse(xml);
      SimpleStateMachine stateMachine = new SimpleStateMachine();
      foreach (XElement element in root.Descendants()
        .Where(desc => !desc.Elements().Any()))
      {
        XElementWrapper wrapper = new XElementWrapper(element);
        stateMachine.HandleText(wrapper);
      }
      return root.ToString(SaveOptions.DisableFormatting);
    }
