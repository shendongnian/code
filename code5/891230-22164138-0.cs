    public class PictureBox : System.Windows.Forms.UserControl
        {
            #region Members
            private System.Windows.Forms.PictureBox PicBox;
            private Panel OuterPanel;
            private Container components = null;
            private string m_sPicName = "";
            #endregion
            #region Constants
            private double ZOOMFACTOR = 1.25;	// = 25% smaller or larger
            private int MINMAX = 5;				// 5 times bigger or smaller than the ctrl
            #endregion
            #region Designer generated code
            private void InitializeComponent()
            {
                this.PicBox = new System.Windows.Forms.PictureBox();
                this.OuterPanel = new System.Windows.Forms.Panel();
                this.OuterPanel.SuspendLayout();
                this.SuspendLayout();
                // 
                // PicBox
                // 
                this.PicBox.Location = new System.Drawing.Point(0, 0);
                this.PicBox.Name = "PicBox";
                this.PicBox.Size = new System.Drawing.Size(150, 140);
                this.PicBox.TabIndex = 3;
                this.PicBox.TabStop = false;
                // 
                // OuterPanel
                // 
                this.OuterPanel.AutoScroll = true;
                this.OuterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.OuterPanel.Controls.Add(this.PicBox);
                this.OuterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                this.OuterPanel.Location = new System.Drawing.Point(0, 0);
                this.OuterPanel.Name = "OuterPanel";
                this.OuterPanel.Size = new System.Drawing.Size(210, 190);
                this.OuterPanel.TabIndex = 4;
                // 
                // PictureBox
                // 
                this.Controls.Add(this.OuterPanel);
                this.Name = "PictureBox";
                this.Size = new System.Drawing.Size(210, 190);
                this.OuterPanel.ResumeLayout(false);
                this.ResumeLayout(false);
            }
            #endregion
            #region Constructors
            public PictureBox()
            {
                InitializeComponent();
                InitCtrl();	// my special settings for the ctrl
            }
            #endregion
            #region Properties
            private Image _pictureImage;
            public Image PictureImage
            {
                get { return _pictureImage; }
                set
                {
                    if (null != value)
                    {
                        try
                        {
                            PicBox.Image = value;
                            _pictureImage = value;
                        }
                        catch (OutOfMemoryException ex)
                        {
                            RedCross();
                        }
                    }
                    else
                    {
                        RedCross();
                    }
                }
            }
            /// <summary>
            /// Property to select the picture which is displayed in the picturebox. If the 
            /// file doesn´t exist or we receive an exception, the picturebox displays 
            /// a red cross.
            /// </summary>
            /// <value>Complete filename of the picture, including path information</value>
            /// <remarks>Supported fileformat: *.gif, *.tif, *.jpg, *.bmp</remarks>
            /// 
            [Browsable(false)]
            public string Picture
            {
                get { return m_sPicName; }
                set
                {
                    if (null != value)
                    {
                        if (System.IO.File.Exists(value))
                        {
                            try
                            {
                                PicBox.Image = Image.FromFile(value);
                                m_sPicName = value;
                            }
                            catch (OutOfMemoryException ex)
                            {
                                RedCross();
                            }
                        }
                        else
                        {
                            RedCross();
                        }
                    }
                }
            }
            /// <summary>
            /// Set the frametype of the picturbox
            /// </summary>
            [Browsable(false)]
            public BorderStyle Border
            {
                get { return OuterPanel.BorderStyle; }
                set { OuterPanel.BorderStyle = value; }
            }
            #endregion
            #region Other Methods
            /// <summary>
            /// Special settings for the picturebox ctrl
            /// </summary>
            private void InitCtrl()
            {
                PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                PicBox.Location = new Point(0, 0);
                OuterPanel.Dock = DockStyle.Fill;
                OuterPanel.Cursor = System.Windows.Forms.Cursors.NoMove2D;
                OuterPanel.AutoScroll = true;
                OuterPanel.MouseEnter += new EventHandler(PicBox_MouseEnter);
                PicBox.MouseEnter += new EventHandler(PicBox_MouseEnter);
                OuterPanel.MouseWheel += new MouseEventHandler(PicBox_MouseWheel);
            }
            /// <summary>
            /// Create a simple red cross as a bitmap and display it in the picturebox
            /// </summary>
            private void RedCross()
            {
                Bitmap bmp = new Bitmap(OuterPanel.Width, OuterPanel.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
                Graphics gr;
                gr = Graphics.FromImage(bmp);
                Pen pencil = new Pen(Color.Red, 5);
                gr.DrawLine(pencil, 0, 0, OuterPanel.Width, OuterPanel.Height);
                gr.DrawLine(pencil, 0, OuterPanel.Height, OuterPanel.Width, 0);
                PicBox.Image = bmp;
                gr.Dispose();
            }
            #endregion
            #region Zooming Methods
            /// <summary>
            /// Make the PictureBox dimensions larger to effect the Zoom.
            /// </summary>
            /// <remarks>Maximum 5 times bigger</remarks>
            private void ZoomIn()
            {
                if ((PicBox.Width < (MINMAX * OuterPanel.Width)) &&
                    (PicBox.Height < (MINMAX * OuterPanel.Height)))
                {
                    PicBox.Width = Convert.ToInt32(PicBox.Width * ZOOMFACTOR);
                    PicBox.Height = Convert.ToInt32(PicBox.Height * ZOOMFACTOR);
                    PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            /// <summary>
            /// Make the PictureBox dimensions smaller to effect the Zoom.
            /// </summary>
            /// <remarks>Minimum 5 times smaller</remarks>
            private void ZoomOut()
            {
                if ((PicBox.Width > (OuterPanel.Width / MINMAX)) &&
                    (PicBox.Height > (OuterPanel.Height / MINMAX)))
                {
                    PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    PicBox.Width = Convert.ToInt32(PicBox.Width / ZOOMFACTOR);
                    PicBox.Height = Convert.ToInt32(PicBox.Height / ZOOMFACTOR);
                }
            }
            #endregion
            #region Mouse events
            /// <summary>
            /// We use the mousewheel to zoom the picture in or out
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void PicBox_MouseWheel(object sender, MouseEventArgs e)
            {
                if (e.Delta < 0)
                {
                    ZoomIn();
                }
                else
                {
                    ZoomOut();
                }
            }
            /// <summary>
            /// Make sure that the PicBox have the focus, otherwise it doesn´t receive 
            /// mousewheel events !.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void PicBox_MouseEnter(object sender, EventArgs e)
            {
                if (PicBox.Focused == false)
                {
                    PicBox.Focus();
                }
            }
            #endregion
            #region Disposing
            /// <summary>
            /// Die verwendeten Ressourcen bereinigen.
            /// </summary>
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (components != null)
                        components.Dispose();
                }
                base.Dispose(disposing);
            }
            #endregion
        }
  
     private void Form2_Load(object sender, EventArgs e)
     {
          pictureBox1.PictureImage = Image.FromStream(Decrypt.ms1);
     }
