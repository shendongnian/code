    [Desiner(typeof(CustomDesigner))]
    public class ControWithTitle : Panel // Panel 1
    {
       //....
    }
    public class CustomDesigner : ParentControlDesigner {
       public override void Initialize(IComponent component){
          ControWithTitle control = Control as ControWithTitle;
          if(control != null){
            //Enable designmode for Panel3
            EnableDesignMode(control.Content, "Content");
          }
       }
    }
