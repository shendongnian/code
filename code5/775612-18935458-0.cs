    public partial class Form1 : Form, IMessageFilter {
       public Form1(){
         InitializeComponent();
         Application.AddMessageFilter(this);
         //Try this to see it in action
         GlobalClick += (s,e) => {
            l.Text = "Clicked";
         };
       }
       public event EventHandler GlobalClick;
       public bool PreFilterMessage(ref Message m){
         if(m.Msg == 0x202){//WM_LBUTTONUP
            EventHandler handler = GlobalClick;
            if(handler != null) handler(this, EventArgs.Empty);
         }
         return false;
       }
    }
