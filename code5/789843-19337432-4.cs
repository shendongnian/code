    public interface INotifyChangeStyle {
       void ChangeStyle();
    }    
    public class FormBase : Form, INotifyChangeStyle {
       protected override void OnLoad(EventArgs e){
          ChangeStyle();
       }
       public void ChangeStyle(){
          //Perform style changing here
          Color colBackColor = Properties.Settings.Default.basicBackground;
          BackColor = colBackColor;
          //--------
          foreach(var c in Controls.OfType<INotifyChangeStyle>()){
             c.ChangeStyle();
          }
       }
    }
    public class MyButton : Button, INotifyChangeStyle {
       public void ChangeStyle(){
          //Perform style changing here
          //....
          //--------
          foreach(var c in Controls.OfType<INotifyChangeStyle>()){
             c.ChangeStyle();
          }
       }
    }
    //...   the same for other control classes
