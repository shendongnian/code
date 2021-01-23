    public partial class YourUserControl : UserControl, IMessageFilter {
      public YourUserControl(){
        InitializeComponent();
        Application.AddMessageFilter(this);
      }
      public bool PreFilterMessage(ref Message m){
        if(m.Msg == 0x2a3)//WM_MOUSELEAVE 
        {
           Control c = Control.FromHandle(m.HWnd);
           if (Contains(c)) {
              OnMouseLeave(EventArgs.Empty);
           }
        }
        return false;
      }
    }
