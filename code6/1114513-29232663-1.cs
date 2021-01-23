    public class taskStructure
    {
      public string taskName { get; set; }
      public string taskDescription { get; set; }
      public int Priority { get; set; }
      public string dateAndTime { get; set; }
      public override string ToString()
      {
        // This can be changed to output any form of string that you want your object to represent
        StringBuilder output = new StringBuilder();
        output.AppendLine(String.Format("taskName: {0}", taskName));
        output.AppendLine(String.Format("taskDescription: {0}", taskDescription));
        output.AppendLine(String.Format("Priority: {0}", Priority));
        output.AppendLine(String.Format("dateAndTime: {0}", dateAndTime));
        return output.ToString();
      }
    }
