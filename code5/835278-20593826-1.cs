    public class CustomListBox : ListBox
    {
        public bool ReadOnly { get; set; }
        protected override void WndProc(ref Message m)
        {
            //WM_LBUTTONDOWN = 0x201
            //WM_KEYDOWN = 0x100
            if (ReadOnly && (m.Msg == 0x201 || m.Msg == 0x100)) {
              Focus();//do this to allow mouse wheeling
              return;
            }
            base.WndProc(ref m);
        }        
    }
