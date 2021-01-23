    //must add using System.Reflection
    public partial class Form1 : Form, IMessageFilter 
    {
        bool hovered;
        MethodInfo wndProc;
        public Form1() 
        {
           InitializeComponent();
           Application.AddMessageFilter(this);
           richTextBox1.MouseEnter += (s, e) => { hovered = true; };
           richTextBox1.MouseLeave += (s, e) => { hovered = false; };
           wndProc = typeof(Control).GetMethod("WndProc", BindingFlags.NonPublic | 
                                                          BindingFlags.Instance);
        }
        public bool PreFilterMessage(ref Message m) 
        {
            if (m.Msg == 0x20a && hovered) //WM_MOUSEWHEEL = 0x20a
            {
               Message msg = Message.Create(richTextBox1.Handle, m.Msg, m.WParam, m.LParam);
               wndProc.Invoke(richTextBox1, new object[] { msg });
            }
            return false;
        }
    }
