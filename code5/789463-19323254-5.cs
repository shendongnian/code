    public class MyPage : Page{
         protected void Page_Load(){
          HiddenField info = (HiddenField)myHiddenField;
          MyUserControl control = myusercontrol;
          control.MyProperty = info.Value;
         }
    
    }
