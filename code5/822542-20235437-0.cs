    public class ComboBoxEx : ComboBox
    {    
        public ComboBoxEx(){
            IsHitTestVisible = true;
        }
        public bool IsHitTestVisible { get; set; }
        public bool ReadOnly { get; set; }
        protected override void WndProc(ref Message m)
        {            
            if (!IsHitTestVisible)
            {
                if (m.Msg == 0x21)//WM_MOUSEACTIVATE = 0x21
                {
                    m.Result = (IntPtr)4;//no activation and discard mouse message
                    return;
                }
                //WM_MOUSEMOVE = 0x200, WM_LBUTTONUP = 0x202
                if (m.Msg == 0x200 || m.Msg == 0x202) return;
            }
            //WM_SETFOCUS = 0x7
            if (ReadOnly && m.Msg == 0x7) return;
            base.WndProc(ref m);
        }
        //Discard key messages
        public override bool PreProcessMessage(ref Message msg)
        {
            if (ReadOnly) return true;
            return base.PreProcessMessage(ref msg);
        }
    }
    //Usage
    comboBoxEx1.ReadOnly = true;
    comboBoxEx1.IsHitTestVisible = false;
