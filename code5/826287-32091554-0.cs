        using System;
        using System.Drawing;
        using System.Windows.Forms;
        namespace myNotificationBox
        {
           public partial class frmNotification : Form
           {
            private string _message;
            private int _time = 1000;
    
            public frmNotification(string message)
            {
                InitializeComponent();
                _message = message;
            }
    
            public frmNotification(string message,int time)
            {
                InitializeComponent();
                _message = message;
                _time = time;
            }
    
            private void tmr_Tick(object sender, EventArgs e)
            {
                this.Close();
            }
    
            private void frmNotification_Load(object sender, EventArgs e)
            {
                lblMessage.Text = _message;
                this.Width = _message.Length*10;
                this.Height = 30;
                tmr.Interval = _time;
                tmr.Start();
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                        Color.Teal, 3, ButtonBorderStyle.Solid,
                                        Color.Teal, 3, ButtonBorderStyle.Solid,
                                        Color.Teal, 3, ButtonBorderStyle.Solid,
                                        Color.Teal, 3, ButtonBorderStyle.Solid);
                //Rectangle rect = this.ClientRectangle;
                //LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Snow, Color.SeaShell, 60); //LightCyan Lavender LightGray
                //e.Graphics.FillRectangle(brush, rect);
                //base.OnPaint(e);
            }
    
            #region Overloaded Show message to display message box.
    
            /// <summary>
            /// Show method is overloaded which is used to display message
            /// and this is static method so that we don't need to create 
            /// object of this class to call this method.
            /// </summary>
            /// <param name="messageText"></param>
            /// 
    
            internal static DialogResult Show(string messageText)
            {
                frmNotification frmNotification = new frmNotification(messageText);
                frmNotification.ShowDialog();
                return frmNotification.DialogResult;
            }
    
            internal static DialogResult Show(string messageText, int time)
            {
                frmNotification frmNotification = new frmNotification(messageText, time);
                frmNotification.ShowDialog();
                return frmNotification.DialogResult;
            }
    
            #endregion
    
        }
        }
