    public class CustomLabel : Label {
      public CustomLabel(){
         IsCentered = true;
      }
      public bool IsCentered {get;set;}//You can define an Enum if needed
      protected override void OnSizeChanged(EventArgs e){
        if(Parent != null&&IsCentered){
           Left = (Parent.Width - Width)/2;
        }
      }
      protected override void OnParentChanged(EventArgs e){
         if(Parent != null){
            Parent.SizedChanged -= parent_SizeChanged;
            Parent.SizedChanged += parent_SizeChanged;
         }
      }
      private void parent_SizeChanged(object sender, EventArgs e){
        if(IsCentered) Left = (Parent.Width - Width)/2;
      }
    }
