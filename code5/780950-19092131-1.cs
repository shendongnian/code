    private void RegisterTextChangedEventHandler(Control root){
       Stack<Control> stack = new Stack<Control>();
       stack.Push(root);  
       Control current = null;     
       while(stack.Count>0){
          current = stack.Pop();
          foreach(var c in current.Controls.OfType<TextBox>()){
             c.TextChanged += textChanged;
             stack.Push(c);
          }
       }
    }
    private void textChanged(object sender, EventArgs e){
       //....
    }
    //Use it
    RegisterTextChangedEventHandler(yourForm);//Or your container ....
