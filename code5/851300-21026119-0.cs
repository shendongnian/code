    [Serializable]
    public class CheckboxItem
    {
      public string Text { get; set; }
      public string Value { get; set; }
      public CheckboxItem(string value, string text)
      {
          Value = value;
          Text = text;
      }
      public override string ToString()
      {
        return Text;
      }
    }
