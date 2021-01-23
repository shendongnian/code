     [Register("MyTextField")]
     public class MyTextField : UITextField
     {
         public MyTextField() {
            HookEvent();
         }
         public MyTextField(IntPtr ptr) {
            HookEvent();
         }
         // other ctors as needed
         private void HookEvent() {
            EditingChanged += (s, e) => MyTextChanged.Raise(this);
         }
         public string MyText {
            get { return Text; }
            set { Text = value; MyTextChanged.Raise(this); }
         }
         public event EventHandler MyTextChanged;
     }
