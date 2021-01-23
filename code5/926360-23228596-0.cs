     public class MyEditText : EditText
     {
         public MyEditText(Context c, IAttributeSet a) : base(c,a) {
            this.EditorAction += EventHandlerContrato;
         }
         public ICommand KeyCommand { get;set; }
         public void EventHandlerContrato(object MyObject,EditText.EditorActionEventArgs e){
            e.Handled = false;
            if (e.ActionId == Android.Views.InputMethods.ImeAction.ImeNull ||
                e.ActionId == Android.Views.InputMethods.ImeAction.Next ||
                e.ActionId == Android.Views.InputMethods.ImeAction.Unspecified ||
                e.ActionId == Android.Views.InputMethods.ImeAction.None ||
                e.ActionId == Android.Views.InputMethods.ImeAction.Send ||
                e.ActionId == Android.Views.InputMethods.ImeAction.Go)
            {
                if (KeyCommand != null) {
                   KeyCommand.Execute(null);
                   e.Handled = true;
                }
           }
        }
     }
