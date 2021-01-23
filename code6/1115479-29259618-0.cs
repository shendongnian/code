    public class Miniräknare
    {
      public Miniräknare()
      {
        // Have a default constructor that sets all the default properties
        First = 0;
        Second = 0;
        Op = "";
        Memory = 0;
        Change = false;
      }
      public Miniräknare(double first, double second, string op, double memory, bool change)
      {
        // If you have a constructor with parameters, use the parameters to set your properties
        First = first;
        Second = second;
        Op = op;
        Memory = memory;
        Change = change;
      }
      // Use automatic properties, this improves readability and less confusion (As per D Stanley in comments)
      public double First { get; set; }
      public double Second { get; set; }
      public string Op { get; set; }
      public double Memory { get; set; }
      public bool Change { get; set; }
      public string getOperand(string t, string textBox)
      {
        // Apply changes as per the accepted answer
        textBox = textBox + t;
        if (t.Equals(","))
        {
          Change = true;
          Second = double.Parse(textBox);
        }
        else if (Op.Equals(""))
        {
          if (!Change)
          {
            textBox = "";
            Change = true;
            textBox = textBox + t;
          }
          First = double.Parse(textBox);
        }
        else
        {
          if (!Change)
          {
            textBox = "";
            Change = true;
            textBox = textBox + t;
          }
          Second = double.Parse(textBox);
        }
        return textBox;
      }
      public string doEquals()
      {
        if (Op == "-") return (First - Second).ToString();
        else return null;
      }
    }
