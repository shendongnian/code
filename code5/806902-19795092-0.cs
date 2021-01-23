    public partial class Form1 : Form {
       public Form1(){
         InitializeComponent();
       }
       bool shownModal;//This flag will be used to determine if there is some
                      //modal dialog opening.
       protected override void WndProc(ref Message m) {
            if (m.Msg == 0x112)//WM_SYSCOMMAND
            {
                //SC_CLOSE = 0xf060  
                if (m.WParam.ToInt32() == 0xf060 && 
                    m.LParam.ToInt32() == 0 && shownModal)
                {
                    //Your own code here
                    //You can close the main form or close the modal dialog
                    Close();
                }
            }
            base.WndProc(ref m);            
        }
    }
