    public partial class Form1 : Form {
      public Form1(){
        InitializeComponent();
         t.Interval = 600;
         t.Tick += (se, ev) => {
           buttonToolTip.SetToolTip(comboBox1, (string)comboBox1.SelectedItem);
           t.Stop();
         };
         //init the buttonToolTip
         buttonToolTip.ToolTipTitle = "Value";
         buttonToolTip.UseFading = true;
         buttonToolTip.UseAnimation = true;
         buttonToolTip.IsBalloon = true;
         buttonToolTip.ShowAlways = true;
         buttonToolTip.AutoPopDelay = 5000;
         buttonToolTip.InitialDelay = 1000;
         buttonToolTip.ReshowDelay = 0;
         //register MouseMove event handler for your comboBox1
         comboBox1.MouseMove += (se, ev) => {                    
           //Restart the timer every time the mouse is moving
           t.Stop();
           t.Start();
         };
      }
      Timer t = new Timer();
      ToolTip buttonToolTip = new ToolTip();
    }
