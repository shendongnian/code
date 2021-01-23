    public interface ITextReplacer
    {
      string ReplaceValue(string value);
    }
    public class DefaultTextReplacer : ITextReplacer
    {
      public string ReplaceValue(string value) { return $"{value.ToUpper()}"; }
    }
    public class SimpleStateMachineXml
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
      public List<XElement> TextsList { get; } = new List<XElement>();
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
      public void Add(XElement text)
      {
        if (TextsList.Count == 0 || TextsList.Last() != text)
        {
          TextsList.Add(text);
        }
      }
      public void HandleText(XElement text)
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
                    TextsList[j].Remove();
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
      SimpleStateMachineXml stateMachine = new SimpleStateMachineXml();
      foreach (XElement element in root.Descendants()
       .Where(desc => !desc.Elements().Any()))
      {
        stateMachine.HandleText(element);
      }
      return root.ToString(SaveOptions.DisableFormatting);
    }
    static void Main(string[] args)
    {
      string v;
      v = Test("<r><t>${abc</t><t>}$</t><t>{tha}</t></r>");
      Console.WriteLine("{0}, {1}", v, v == "<r><t>ABC</t><t>THA</t><t></t></r>");
      v = Test("<r><t>$</t><t>{</t><t>abc</t><t>}</t></r>");
      Console.WriteLine("{0}, {1}", v, v == "<r><t>ABC</t><t></t></r>");
      v = Test("<r><t>${abc}</t></r>");
      Console.WriteLine("{0}, {1}", v, v == "<r><t>ABC</t></r>");
      v = Test("<r><t>x${abc}</t></r>");
      Console.WriteLine("{0}, {1}", v, v == "<r><t>xABC</t></r>");
      v = Test("<r><t>x${abc}y</t></r>");
      Console.WriteLine("{0}, {1}", v, v == "<r><t>xABCy</t></r>");
      v = Test("<r><t>x${abc}${tha}z</t></r>");
      Console.WriteLine("{0}, {1}", v, v == "<r><t>xABCTHAz</t></r>");
      v = Test("<r><t>x${abc}u${tha}z</t></r>");
      Console.WriteLine("{0}, {1}", v, v == "<r><t>xABCuTHAz</t></r>");
      v = Test("<r><t>x${ab</t><t>c}u</t></r>");
      Console.WriteLine("{0}, {1}", v, v == "<r><t>xABC</t><t>u</t></r>");
      v = Test("<r><t>x${ab</t><t>yupeekaiiei</t><t>c}u</t></r>");
      Console.WriteLine("{0}, {1}", v, v == "<r><t>xABYUPEEKAIIEIC</t><t>u</t></r>");
      v = Test("<r><t>x${ab</t><t>yupeekaiiei</t><t>}</t></r>");
      Console.WriteLine("{0}, {1}", v, v == "<r><t>xABYUPEEKAIIEI</t><t></t></r>");
      Console.WriteLine("Done!");
      Console.ReadLine();
    }
