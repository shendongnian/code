    public partial class Form1 : Form, IMessageFilter {
       public Form1(){
          InitializeComponent();
       }
       public bool PreFilterMessage(ref Message m){
         if(m.Msg == 0x200){//WM_MOUSEMOVE = 0x200
           ShowToolTip(Control.FromHandle(m.HWnd));
         }
         return false;
       }
       private void ShowToolTip(Control ctrl){
            if (ctrl != null && !ctrl.Enabled)
            {
                if (ctrl.Visible && toolTip1.Tag == null)
                {
                    var tipstring = "My tooltip";// toolTip1.GetToolTip(ctrl);
                    toolTip1.Show(tipstring, ctrl, ctrl.Width / 2, ctrl.Height / 2);
                    toolTip1.Tag = ctrl;
                }
            }
            else
            {
                ctrl = toolTip1.Tag as Control;
                if (ctrl != null)
                {
                    toolTip1.Hide(ctrl);
                    toolTip1.Tag = null;
                }
            }
       }
    }
