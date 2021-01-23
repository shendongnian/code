    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    
    namespace button2
    {
        public partial class Form1 : Form
        {
            private Button button1;
            private GroupBox box;
            public Form1()
            {
                InitializeComponent();
                show();
            }
            private void show()
            {
                box = new GroupBox();
                button1 = new Button();
                button1.Location = new Point(50, 50);
                ElipseControl nn = new ElipseControl();            
                nn.TargetControl = button1;            
                button1.Text = "First Name";
                button1.BackColor = Color.Cyan;
                button1.FlatStyle = FlatStyle.Flat;
                button1.FlatAppearance.BorderSize = 0;
                button1.FlatAppearance.BorderColor = Color.White;
                nn.CornerRadius = 10;
                
                button1.ForeColor = Color.Blue;
                button1.Font = new Font("Arial", 9, FontStyle.Bold);
                box.Controls.Add(button1);
                box.AutoSize = true;
    
    
                this.Controls.Add(box);
    
            }
        }
        class ElipseControl : Component
        {
            [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
            public static extern IntPtr CreateRoundRectRgn
                (
                   int nLeftRect,
                   int nTopRect,
                   int nRightRect,
                   int nBottomRect,
                   int nWidthEllipse,
                   int nHeightEllipse
                );
            private Control _cntrl;
            private int _CornerRadius = 30;
    
            public Control TargetControl
            {
                get { return _cntrl; }
                set
                {
                    _cntrl = value;
                    _cntrl.SizeChanged += (sender, eventArgs) => _cntrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _cntrl.Width, _cntrl.Height, _CornerRadius, _CornerRadius));
                }
            }
    
            public int CornerRadius
            {
                get { return _CornerRadius; }
                set
                {
                    _CornerRadius = value;
                    if (_cntrl != null)
                        _cntrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _cntrl.Width, _cntrl.Height, _CornerRadius, _CornerRadius));
                }
            }
        }
    }
