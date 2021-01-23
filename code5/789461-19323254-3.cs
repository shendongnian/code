    public class MyPage : Page{
         protected void Page_Load(){
          HiddenField info = (HiddenField)myHiddenField;
          MyUserControl control = (MyUserControl ) myusercontrol;
          control.MyProperty = info.Value;
         }
    
    }
