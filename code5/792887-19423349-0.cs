    public partial class Form1 : Form, IMessageFilter {
        public Form1() {
           InitializeComponent();
           Application.AddMessageFilter(this);
           richTextBox1.MouseEnter += (s, e) => {
                hovered = true;
           };
           richTextBox1.MouseLeave += (s, e) => {
                hovered = false;
           };
        }
        bool hovered;
        public bool PreFilterMessage(ref Message m) {
            if (m.Msg == 0x20a && hovered) {//WM_MOUSEWHEEL = 0x20a
               Message msg = Message.Create(richTextBox1.Handle, m.Msg, m.WParam, m.LParam);
               typeof(Control).GetMethod("WndProc", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                              .Invoke(richTextBox1, new object[] { msg });
            }
            return false;
        }
    }
