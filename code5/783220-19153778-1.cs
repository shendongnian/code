    public class MyForm {
       private MyUserControl userControl;
       
       public MyForm() {
         ...
         userControl.MyControlButtonClicked += OnUserControlButtonClicked;
       }
       private void OnUserControlButtonClicked(object sender, EventArgs arguments) {
          // handle the button click here
       }
    }
