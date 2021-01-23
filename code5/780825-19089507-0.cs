    //This code uses some reflection so you must add using System.Reflection
    public partial class Form1 : Form, IMessageFilter
    {
         public Form1(){
           InitializeComponent();
           Application.AddMessageFilter(this);
         }
         public bool PreFilterMessage(ref Message m) {
            Control c = Control.FromHandle(m.HWnd)
            if (HasParent(c,panel1)){                
                if (m.Msg == 0x2a1){//WM_MOUSEHOVER = 0x2a1
                    //Fire the MouseHover event via Reflection
                    typeof(Panel).GetMethod("OnMouseHover", BindingFlags.NonPublic | BindingFlags.Instance)
                        .Invoke(panel1, new object[] {EventArgs.Empty});                    
                }
            }
            return false;
        }
        //This method is used to check if a child control has some control as parent 
        private bool HasParent(Control child, Control parent) {
            if (child == null) return false;
            Control p = child.Parent;
            while (p != null) {
                if (p == parent) return true;
                p = p.Parent;
            }
            return false;
        }
    }
