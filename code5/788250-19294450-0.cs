    //Suppose your disabled Button is button1
    public partial class Form1 : Form, IMessageFilter
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            button1.BackColor = Color.Green;
            //Try this to see it in action
            button1.MouseEnter += (s, e) => {
                button1.BackColor = Color.Red;
            };
            button1.MouseLeave += (s, e) => {
                button1.BackColor = Color.Green;
            };
            Application.AddMessageFilter(this);//Add the IMessageFilter to the current Application
        }
        bool entered;
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x200&&!button1.Enabled) //WM_MOUSEMOVE = 0x200
            {
                if (button1.ClientRectangle.Contains(button1.PointToClient(MousePosition)))
                {
                    if (!entered) {
                        entered = true;
                        //Raise the MouseEnter event via Reflection
                        typeof(Button).GetMethod("OnMouseEnter", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                            .Invoke(button1, new[] { EventArgs.Empty });
                    }                    
                }
                else if (entered) {
                    //Raise the MouseLeave event via Reflection
                    typeof(Button).GetMethod("OnMouseLeave", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        .Invoke(button1, new []{EventArgs.Empty});
                    entered = false;                    
                }
            }
            return false;
        }
    }
