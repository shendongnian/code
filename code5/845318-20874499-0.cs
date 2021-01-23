    public partial class UserControl1 : UserControl
    {
        // The event raised when a user changes color
        [Category("Behavior")]
        public event EventHandler OnSelectionChanged;
        /*
         * Properties
         * 
         */
        private Color[] m_Colors = new Color[] {}; // Colors on the palette
        private Color m_SelectedColor;             // Stores selected color
        private int m_MaxColorsPerLine = 14;       // Max colors per line
        public Color[] Colors
        {
            get { return m_Colors; }
            set { m_Colors = value; }
        }
        [Browsable(false)]
        public Color SelectedColor
        {
            get { return m_SelectedColor; }
        }
        public int MaxColorsPerLine
        {
            get { return m_MaxColorsPerLine; }
            set { m_MaxColorsPerLine = value; }
        }
        public UserControl1()
        {
            InitializeComponent();
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {
            this.Controls.Clear();
            int COLOR_WIDTH = 16;
            int COLOR_HEIGHT = 16;
            // Border colors
            Color NEUTRAL_COLOR = Color.Black;
            Color HIGHLIGHTED_COLOR = Color.Orange;
            Color SELECTED_COLOR = Color.Red;         
            // Populate the palette
            for(int i = 0; i < m_Colors.Length; ++i)
            {
                // Get where the current color should be positioned.
                int linePos = (int)Math.Floor((double) i / m_MaxColorsPerLine);
                int colPos = i % m_MaxColorsPerLine;
                int posX = COLOR_WIDTH * colPos;
                int posY = COLOR_HEIGHT * linePos;
                // Create the panel that will hold the color
                Panel pnl = new Panel();
                pnl.Width = COLOR_WIDTH;
                pnl.Height = COLOR_HEIGHT;
                pnl.Location = new Point(posX, posY);
                pnl.BackColor = m_Colors[i];
                pnl.ForeColor = NEUTRAL_COLOR;
                // Change border color when highlighted
                pnl.MouseEnter += (s, args) => pnl.ForeColor = HIGHLIGHTED_COLOR;
                // Change border color when mouse leaves
                pnl.MouseLeave += (s, args) =>
                {
                    if (pnl.Tag != null && (bool)pnl.Tag == true)
                    {
                        pnl.ForeColor = SELECTED_COLOR; // restore selected border color on mouse leave if selected
                    }
                    else
                    {
                        pnl.ForeColor = NEUTRAL_COLOR; // restore normal border color on mouse leave if not selected
                    }
                };
                    
                // Change border color when selected
                pnl.Click += (s, args) =>
                {
                    if (pnl.Tag == null || (bool)pnl.Tag == false)
                    {
                        pnl.ForeColor = SELECTED_COLOR;
                        pnl.Tag = true; // Use the Tag member to store whether the color is selected
                        m_SelectedColor = pnl.BackColor;
                        // Raise the SelectionChanged event if this panel is not already selected
                        if (OnSelectionChanged != null)
                        {
                            OnSelectionChanged(this, EventArgs.Empty);
                        }
                    }
                    // Unselect other colors
                    foreach (Panel otherColor in this.Controls)
                    {
                        if (otherColor == pnl)
                            continue;
                        if (pnl.Tag != null && (bool)pnl.Tag == true)
                        {
                            otherColor.ForeColor = NEUTRAL_COLOR;
                            otherColor.Tag = false;
                        }
                    }
                };
                // Draw borders
                pnl.Paint += (s, args) =>
                {
                    Rectangle outterRect = args.ClipRectangle;
                    Rectangle innerRect = new Rectangle(outterRect.X + 1, outterRect.Y + 1, outterRect.Width - 3, outterRect.Height - 3);
                    // Draw outter rectangle
                    args.Graphics.DrawRectangle(
                    new Pen(
                        new SolidBrush(pnl.ForeColor), 2),
                        outterRect);
                    // Draw inner rectangle
                    args.Graphics.DrawRectangle(
                    new Pen(
                        Brushes.White, 1),
                        innerRect);
                };
                // Finally, add color panel to the control
                this.Controls.Add(pnl);
                
            }
        }
    }
