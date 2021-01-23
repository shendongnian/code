    public class FormBase : Form {
       protected override void OnLoad(EventArgs e){
        Color colBackColor = Properties.Settings.Default.basicBackground;
        BackColor = colBackColor;
       }
    }
    //Then all other forms have to inherit from that FormBase instead of the standard Form
    public class Form1 : FormBase {
      //...
    }
    public class Form2 : FormBase {
      //...
    }
