    public class Form1 : Form {
       [DllImport("user32")]
       private static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);
       public Form1(){
          InitializeComponent();
          //initialize some properties for your richTextBox1 (this should be added as a child of your panel1)
          richTextBox1.ScrollBars = RichTextBoxScrollBars.Horizontal;
          richTextBox1.BorderStyle = BorderStyle.None;
          richTextBox1.Dock = DockStyle.Top;
          richTextBox1.MinimumSize = new Size(panel1.Width, panel1.Height - 2);
          //initialize some properties for your panel1
          panel1.AutoScroll = true;
          panel1.BorderStyle = BorderStyle.FixedSingle;       
          //If the size of panel1 is changed, we have to update the MinimumSize of richTextBox1.
          panel1.SizeChanged += (s,e) => {
             richTextBox1.MinimumSize = new Size(panel1.Width, panel1.Height - 2);
          };   
          new NativeRichTextBox() { Parent = panel1 }.AssignHandle(richTextBox1.Handle);
          hidden.Parent = panel1;    
       }
       //hidden control of panel1 is used to scroll the thumb when the KeyUp of richTextBox1 is raised.
       Control hidden = new Control();
       //this is used to hook into the message loop of the richTextBox1
       public class NativeRichTextBox : NativeWindow
        {
            public Panel Parent;
            protected override void WndProc(ref Message m)
            {
                
                if (m.Msg == 0x20a)//WM_MOUSEWHEEL = 0x20a
                {                    
                    if (Parent != null)
                    {
                        SendMessage(Parent.Handle, m.Msg, m.WParam, m.LParam);                     
                        return;
                    }
                }
                base.WndProc(ref m);                
            }
        }
       //ContentsResized event handler of your richTextBox1
       private void richTextBox1_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            richTextBox1.Height = e.NewRectangle.Height + 5;            
        }
       //KeyUp event handler of your richTextBox1
       private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
                Point p = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);                                
                hidden.Top = panel1.PointToClient(richTextBox1.PointToScreen(p)).Y;
                hidden.Height = (int) richTextBox1.SelectionFont.Height;
                panel1.ScrollControlIntoView(hidden);                
        }
    }
