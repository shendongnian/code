    public partial class Form1 : Form {
      [DllImport("user32.dll", SetLastError = true)]
      static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
      public Form1(){
         InitializeComponent();
         //Register event handlers for all the toolstripitems initially
         foreach (ToolStripItem item in toolStrip1.Items){
            item.MouseEnter += itemsMouseEnter;
            item.MouseLeave += itemsMouseLeave;
         }
         //We have to do this if we add/remove some toolstripitem at runtime
         //Otherwise we don't need the following code
         toolStrip1.ItemAdded += (s,e) => {
            item.MouseEnter += itemsMouseEnter;
            item.MouseLeave += itemsMouseLeave;
         };
         toolStrip1.ItemRemoved += (s,e) => {
            item.MouseEnter -= itemsMouseEnter;
            item.MouseLeave -= itemsMouseLeave;
         };
      }
      bool pressedAlt;
      private void itemsMouseEnter(object sender, EventArgs e){
            if (!pressedAlt) {
                //Hold the Alt key
                keybd_event(0x12, 0, 0, 0);//VK_ALT = 0x12
                pressedAlt = true;
            }
      }
      private void itemsMouseLeave(object sender, EventArgs e){
            if (pressedAlt){
                //Release the Alt key
                keybd_event(0x12, 0, 2, 0);//flags = 2  -> Release the key
                pressedAlt = false;
                SendKeys.Send("ESC");//Do this to make the GUI active again
            }            
      }
    }
