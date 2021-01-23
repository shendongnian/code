    public interface IMenuItem
    {
      String Title { get; set; }
      String Contents { get; set; }
      List<MenuItem> Submenus { get; set; }
      String Source { get; set; }
      String SourceType { get; set; }
      void DisplayContents();
    }
    public class MenuItem: IMenuItem
    {
      public String Title { get; set; }
      public String Contents { get; set; }
      public List<MenuItem> Submenus { get; set; }
      public String Source { get; set; }
      public String SourceType { get; set; }
      public virtual void DisplayContents() { MessageBox.Show(Title); }
    }
    // Very very basic implementation of the classes, just to show what can be done
    public class FileMenu : MenuItem { public override void DisplayContents() { MessageBox.Show(Title + this.GetType().ToString()); } }
    public class FolderMenu : MenuItem { public override void DisplayContents() { MessageBox.Show(Title + "Folder Class"); } }
    public class JsonMenu : MenuItem { public override void DisplayContents() { MessageBox.Show(Contents); } }
    public class RestMenu : MenuItem { public override void DisplayContents() { MessageBox.Show(Source); } }
    public class RssMenu : MenuItem { public override void DisplayContents() { MessageBox.Show(SourceType); } }
    public class TextMenu : MenuItem { public override void DisplayContents() { MessageBox.Show(Title); } }
    public class UrlMenu : MenuItem { public override void DisplayContents() { MessageBox.Show(Title); } }
