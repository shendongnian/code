    //Create a custom RichTextBox class
    public class CustomRichTextBox : RichTextBox {
       protected override void WndProc(ref Message m){
         if(m.Msg == 0x50) return; //WM_INPUTLANGCHANGEREQUEST = 0x50
         base.WndProc(ref m);
       }
       public override bool PreProcessMessage(ref Message msg) {            
            if (msg.Msg == 0x100)//WM_KEYDOWN = 0x100
            {
               Keys keyData = (Keys)msg.WParam | ModifierKeys;
               if(keyData == (Keys.Control | Keys.Shift | Keys.D0)){
                 //your own code goes here...
               }
            }
            return base.PreProcessMessage(ref msg);
       }
    }
