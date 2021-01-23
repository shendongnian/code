    public partial class Form1 : Form {
      public Form1(){
         InitializeComponent();
      }
      protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
        if (keyData == (Keys.Alt  | Keys.P)) {
           tabCtrlIPE.SelectedIndex = 3;
           return true;//Prevent beep sound
        }
        return base.ProcessCmdKey(ref msg, keyData);
      }
    }
