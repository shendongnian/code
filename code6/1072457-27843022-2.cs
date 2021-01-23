    public class MenuDetailPage: MasterDetailPage{
      public MenuDetailPage(): base(){
        this.Master = BuildMyMenuListHere(); // the menu items will also define navigation targets
      }
    }
