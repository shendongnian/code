        private static System.Threading.Timer Tmr;
        public static void Show(Form Parent, string text, int timeout)
        {
            Form mbx = new Form();
            Label LblMessage = new Label();
            #region InitializeComponent
            mbx.Size = new System.Drawing.Size(308, 185);
            mbx.MaximizeBox = false;
            mbx.MinimizeBox = false;
            mbx.ShowIcon = false;
            mbx.ShowInTaskbar = false;
            mbx.ControlBox = false;
            mbx.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            mbx.FormBorderStyle = FormBorderStyle.None;
            mbx.StartPosition = FormStartPosition.CenterScreen;
            #region Center on Parent StartPosition
            if (Parent != null)
            {
                mbx.BackColor = Parent.BackColor;
                mbx.StartPosition = FormStartPosition.Manual;
                int X = Parent.Location.X + ((Parent.Width - mbx.Width) / 2);
                int Y = Parent.Location.Y + ((Parent.Height - mbx.Height) / 2);
                mbx.Location = new System.Drawing.Point(X, Y);
            }
            #endregion
            //
            //LblMessage
            //
            LblMessage.Location = new System.Drawing.Point(12, 23);
            LblMessage.AutoSize = false;
            LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            LblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            LblMessage.ForeColor = mbx.BackColor.ToInvert();
            LblMessage.BorderStyle = BorderStyle.FixedSingle;
            LblMessage.Text = text;
            LblMessage.Dock = DockStyle.Fill;
            mbx.Controls.Add(LblMessage);
            #endregion
            Tmr = new System.Threading.Timer(new System.Threading.TimerCallback(Tmr_Tick), mbx, timeout, 0);
            mbx.ShowDialog();
        }
        private static void Tmr_Tick(object obj)
        {
            Tmr.Dispose();
            if (obj is Form)
            {
                if (((Form)obj).InvokeRequired)
                {
                    ((Form)obj).Invoke(new System.Action<Form>(InvokeMbx), new object[] { ((Form)obj) });
                }
                else InvokeMbx((Form)obj);
            }
        }
        private static void InvokeMbx(Form mbx)
        {
            mbx.Close();
        }
    }
