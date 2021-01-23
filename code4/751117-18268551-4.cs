    public class CustomLabel : Label {
      public CustomLabel(){
         IsCentered = true;
      }
      private Control oldParent;
      public bool IsCentered {get;set;}//You can define an Enum if needed
      protected override void OnSizeChanged(EventArgs e){
        if(Parent != null&&IsCentered){
           Center();
        }
      }
      protected override void OnParentChanged(EventArgs e){
         if(Parent != null){
            if(oldParent != null) oldParent.SizedChanged -= parent_SizeChanged;
            Parent.SizedChanged -= parent_SizeChanged;
            Parent.SizedChanged += parent_SizeChanged;
            Center();
         }
         oldParent = Parent;
      }
      private void parent_SizeChanged(object sender, EventArgs e){
        if(IsCentered) Center();
      }
      public void Center(){
        Left = (Parent.Width - Width)/2;
      }
    }
