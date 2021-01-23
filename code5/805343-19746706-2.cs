    public class NativeTextBox : NativeWindow {
        public Dictionary<char, char> CharMappings;
        public NativeTextBox(Dictionary<char,char> charMappings){
          CharMappings = charMappings;
        }
        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x302){ //WM_PASTE
                string s = Clipboard.GetText();
                foreach (var e in CharMappings){
                  s = s.Replace(e.Key, e.Value);
                }                
                Clipboard.SetText(s);
            }
            base.WndProc(ref m);
        }
    }
    //Then hook it up like this (place in your form constructor)
    new NativeTextBox(dict).AssignHandle(textBox1.Handle);
