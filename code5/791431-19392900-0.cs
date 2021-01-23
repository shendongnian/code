    public class MyData {
      public MyData() {
        Date = DateTime.MinValue;
      }
      public int ID { get; set; }
      public string Text { get; set; }
      public DateTime Date { get; set; }
      public override ToString() {
        return string.Format("{0}: {1}", ID, Text);
      }
    }
