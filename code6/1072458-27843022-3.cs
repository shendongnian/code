    public class FirstDetailWithMenuPage: MenuDetailPage{
      public FirstDetailWithMenuPage()
        : base() // this creates the menu
      {
        this.Detail = new StackLayout{  // change this however you need
          Children = {
            new Label { Text = "This is the first page" },
            new Button { Text= "Ok"},
         }
      }
    }
