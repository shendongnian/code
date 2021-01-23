    public partial class YourUserControl : UserControl, IMessageFilter {
      public YourUserControl(){
        InitializeComponent();
        Application.AddMessageFilter(this);
      }
      bool entered;
      public bool PreFilterMessage(ref Message m) {
        if (m.Msg == 0x2a3 && entered) return true;//discard the default MouseLeave inside         
        if (m.Msg == 0x200) {                
          Control c = Control.FromHandle(m.HWnd);
          if (Contains(c) || c == this) {                    
             if (!entered) {
                OnMouseEnter(EventArgs.Empty);
                entered = true;                  
              }                   
          } else if (entered) {
             OnMouseLeave(EventArgs.Empty);
             entered = false;                    
          }
        }
        return false;
      }
    }
