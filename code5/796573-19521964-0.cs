    //Use this class to add message interceptor into your ToolStrip message loop
    public class NativeToolStrip : NativeWindow {
        ToolStrip ts;
        bool letClicked;
        protected override void OnHandleChange() {
            base.OnHandleChange();
            Control c = Control.FromHandle(Handle);
            ts = c as ToolStrip;
        }
        protected override void WndProc(ref Message m) {                
          if (m.Msg == 0x202&&!letClicked) {//WM_LBUTTONUP = 0x202
               int x = m.LParam.ToInt32() & 0x00ff;
               int y = m.LParam.ToInt32() >> 16;
               ToolStripItem item = ts.GetItemAt(new Point(x, y));                    
               //check if the first item (the Print Button) is clicked
               if (item != null && ts.Items.IndexOf(item) == 0) {
                 if (MessageBox.Show("Do you want to print?", "Print confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                     return;//discard message
                 else {
                        letClicked = true;
                        item.PerformClick();
                  }
                }
           }
           base.WndProc(ref m);
           if (letClicked) letClicked = false;
        }
    }
    //This code should be done somewhere like in your form constructor
    //BUT your PrintPreviewDialog should also be declared once in the form scope
    //You can also place this in your button5_Click BUT it's not recommended
    ToolStrip ts = (ToolStrip)ppd.Controls[1];
    new NativeToolStrip().AssignHandle(ts.Handle);
