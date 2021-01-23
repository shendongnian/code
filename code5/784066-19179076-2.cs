     public partial class UCTextBoxCustomcs : UserControl
        {
            private ToolTip _errorToolTip;
    
            // keep original background color so you can change it when txet value is OK
            private Color _orgBgColor;
            public new Color BackColor
            {
                get { return _orgBgColor; }
                set 
                { 
                    base.BackColor = value;
                    _orgBgColor = value;
                    
                }
            }
    
            public new string Text
            {
                get { return this.txbContent.Text; }
                set { this.txbContent.Text = value; }
            }
    
            public Color InvalidBgColor { get; set; }
    
            private bool _IsValid;
            public bool IsValid
            {
                get { return _IsValid; }
                set 
                {
                    _IsValid = value;
                    if (value)
                    {
                        base.BackColor = _orgBgColor;
                        _errorToolTip.SetToolTip(this.txbContent, "");
                        _errorToolTip.ShowAlways = false;
                        _errorToolTip.Hide(this.txbContent);
                    }
                    else
                    {
                        base.BackColor = InvalidBgColor;
                        _errorToolTip.ShowAlways = true;
                        this._errorToolTip.BackColor = InvalidBgColor;
                        _errorToolTip.Show(this.ErrorText, this.txbContent,this.txbContent.Width +3 ,0);
                    }
    
                }
            }
    
            private string _ErrorText;
    
            public string ErrorText
            {
                get 
                { 
                    return _ErrorText;
                }
                set 
                {
                    _ErrorText = value;
                    if (value == null || value.Length == 0) IsValid = true;
                    else IsValid = false;
                }
            }
            
    
            public UCTextBoxCustomcs()
            {
                this._errorToolTip = new ToolTip();
                // BackColor in ToolTip is ignored, so if you want to change it,
                // you have to draw it yourself
                this._errorToolTip.OwnerDraw = true;
                _errorToolTip.Draw += new DrawToolTipEventHandler(_errorToolTip_Draw);
                _errorToolTip.Popup += new PopupEventHandler(_errorToolTip_Popup);
           
                // white background so it looks like TextBox
                this.BackColor = Color.White;
    
                InitializeComponent();
                this.txbContent.BorderStyle = BorderStyle.None;
                // Intelisense tells you this property isn't there, but it is
                // you have to set it to false so TextBox height can be changed
                // when MultiLine is set to false
                this.txbContent.AutoSize = false;
                this.txbContent.Multiline = false;
                // Leave 1 pixel around TextBox for pseudo-border
                this.Padding = new Padding(1);
                this.txbContent.Dock = DockStyle.Fill;
    
                this.InvalidBgColor = Color.Red;
                this.IsValid = true;
            }
    
            void _errorToolTip_Popup(object sender, PopupEventArgs e)
            {
                using (Font f = new Font("Calibri", 9))
                {
                    Size ttSize = TextRenderer.MeasureText(
                        _errorToolTip.GetToolTip(e.AssociatedControl), f);
                    e.ToolTipSize = new Size(ttSize.Width + 6, ttSize.Height + 6);
                }
            }
    
            void _errorToolTip_Draw(object sender, DrawToolTipEventArgs e)
            {
                // In this case a simple rectangle is drawn, but you can draw whatever you want
                // Draw the custom background.
                e.Graphics.FillRectangle(new SolidBrush(this.InvalidBgColor), e.Bounds);
    
                // Draw the standard border.
                e.DrawBorder();
    
                // Draw the custom text. 
                // The using block will dispose the StringFormat automatically. 
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
                    sf.FormatFlags = StringFormatFlags.NoWrap;
                    using (Font f = new Font("Calibri", 9))
                    {
                        Rectangle textBounds = new Rectangle(
                            e.Bounds.Left+3,
                            e.Bounds.Top+3,
                            e.Bounds.Width-6,
                            e.Bounds.Height-6);
                        e.Graphics.DrawString(e.ToolTipText, f,
                            SystemBrushes.ActiveCaptionText, e.Bounds, sf);
                    }
                }
            }
    
            protected override void OnValidating(CancelEventArgs e)
            {
                this.ValidateChildren();
                base.OnValidating(e);
            }
        }
 
