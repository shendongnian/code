    class MCDUComboBox : MCDUStateControl
    {
        public event EventHandler<GosNIIAS.EventArgs<string>> SelectedIndexChanged;
        private const int buttonOffset = 2;
        private const int buttonWidth = 20;
        private const int buttonHeight = 20;
        private string[] m_items;
        private int m_hightlight_index;
        private int m_selected_index;
        private Rectangle m_drop_down_bounds;
        private int m_scroll_index;
        private ButtonState m_top_scroll_button_state;
        private ButtonState m_bottom_scroll_button_state;
        #region Properties
        public string[] Items
        {
            get { return m_items; }
            set { m_items = value; }
        }
        public override string Text
        {
            get { return base.Text; }
            set
            {
                if (ControlState == ControlState.Normal)
                    base.Text = value;
            }
        }
        #endregion
        public MCDUComboBox()
        {
            this.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_items = new string[0];
            this.m_hightlight_index = -1;
            this.m_selected_index = -1;
            this.m_drop_down_bounds = new Rectangle();
            this.m_scroll_index = 0;
            this.m_top_scroll_button_state = ButtonState.Normal;
            this.m_bottom_scroll_button_state = ButtonState.Normal;
        }
        public override void Draw(Graphics g)
        {
            if (Visible)
            {
                Rectangle bounds = ClipRectangle;
                if (ControlState == ControlState.Normal)
                {
                    g.FillRectangle(BackBrush, bounds);
                    g.DrawString(Text, Font, ForeBrush, bounds, StringFormat);
                }
                else if (ControlState == ControlState.Edit)
                {
                    g.FillRectangle(ForeBrush, bounds);
                    ControlPaint.DrawBorder3D(g, bounds, Border3DStyle.Sunken);
                    Rectangle rectangle = new Rectangle(bounds.X + bounds.Width - buttonOffset - buttonWidth,
                                                        bounds.Y + buttonOffset,
                                                        buttonWidth,
                                                        bounds.Height - 2 * buttonOffset);
                    ControlPaint.DrawComboButton(g, rectangle, ButtonState.Normal);
                }
                else if (ControlState == ControlState.WaitingFeedback)
                {
                    g.FillRectangle(BackBrush, bounds);
                    g.DrawString(Text, Font, WaitFeedbackBrush, bounds, StringFormat);
                }
            }
        }
        public override void OnMouseDown(MouseEventArgs e)
        {
            if (Visible)
            {
                Rectangle bounds = ClipRectangle;
                if (bounds.Contains(e.Location))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (ControlState == ControlState.Normal)
                            ControlState = ControlState.Edit;
                    }
                }
                else
                {
                    if (ControlState == ControlState.Edit)
                        ControlState = ControlState.Normal;
                }
            }
        }
        public override bool OnMouseDownTopLayer(MouseEventArgs e)
        {
            if (Visible && ControlState == MCDU.Drawing.ControlState.Edit)
            {
                if (m_drop_down_bounds.Contains(e.Location) && m_items.Length > 0)
                {
                    Rectangle bounds = new Rectangle(m_drop_down_bounds.X,
                                                     m_drop_down_bounds.Y,
                                                     m_items.Length > 10 ? m_drop_down_bounds.Width - buttonWidth 
                                                                         : m_drop_down_bounds.Width,
                                                     m_drop_down_bounds.Height);
                    if (bounds.Contains(e.Location))
                    {
                        if (SelectedIndexChanged != null)
                        {
                            int itemHeight = m_drop_down_bounds.Height / Math.Min(10, m_items.Length);
                            m_selected_index = (e.Location.Y - m_drop_down_bounds.Y) / itemHeight;
                            string text = m_items[m_selected_index + m_scroll_index];
                            SelectedIndexChanged(this, new GosNIIAS.EventArgs<string>(text));
                            base.Text = text;
                            ControlState = ControlState.WaitingFeedback;
                        }
                        else
                            ControlState = ControlState.Normal;
                    }
                    else
                    {
                        bounds = new Rectangle(m_drop_down_bounds.X + m_drop_down_bounds.Width - buttonWidth,
                                               m_drop_down_bounds.Y,
                                               buttonWidth,
                                               buttonHeight);
                        if (bounds.Contains(e.Location))
                        {
                            m_scroll_index -= 1;
                            m_scroll_index = Math.Max(0, m_scroll_index);
                            m_top_scroll_button_state = ButtonState.Pushed;
                        }
                        else
                        {
                            bounds = new Rectangle(m_drop_down_bounds.X + m_drop_down_bounds.Width - buttonWidth,
                                                   m_drop_down_bounds.Y + m_drop_down_bounds.Height - buttonHeight,
                                                   buttonWidth,
                                                   buttonHeight);
                            if (bounds.Contains(e.Location))
                            {
                                m_scroll_index += 1;
                                m_scroll_index = Math.Min(m_items.Length - 10, m_scroll_index);
                                m_bottom_scroll_button_state = ButtonState.Pushed;
                            }
                        }
                    }
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        public override void OnMouseMove(MouseEventArgs e)
        {
            if (Visible && ControlState == MCDU.Drawing.ControlState.Edit)
            {
                if (m_drop_down_bounds.Contains(e.Location))
                {
                    Rectangle bounds = new Rectangle(m_drop_down_bounds.X,
                                                     m_drop_down_bounds.Y,
                                                     m_items.Length > 10 ? m_drop_down_bounds.Width - buttonWidth 
                                                                         : m_drop_down_bounds.Width,
                                                     m_drop_down_bounds.Height);
                    if (bounds.Contains(e.Location) && m_items.Length > 0)
                    {
                        int itemHeight = m_drop_down_bounds.Height / Math.Min(10, m_items.Length);
                        m_hightlight_index = (e.Location.Y - m_drop_down_bounds.Y) / itemHeight + m_scroll_index;
                    }
                }
            }
        }
        public override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            m_top_scroll_button_state = ButtonState.Normal;
            m_bottom_scroll_button_state = ButtonState.Normal;
        }
        public override void DrawTopLayer(Graphics g)
        {
            if (Visible && ControlState == MCDU.Drawing.ControlState.Edit)
            {
                int itemHeight = GetItemHeight(g);
                Rectangle bounds = ClipRectangle;
                m_drop_down_bounds = new Rectangle(bounds.X,
                                                   bounds.Y + bounds.Height,
                                                   bounds.Width,
                                                   itemHeight * Math.Max(1, Math.Min(10, m_items.Length)) + 2);
                g.FillRectangle(ForeBrush, m_drop_down_bounds);
                g.DrawRectangle(new Pen(BackColor), new Rectangle(m_drop_down_bounds.X,
                                                                  m_drop_down_bounds.Y,
                                                                  m_drop_down_bounds.Width - 1,
                                                                  m_drop_down_bounds.Height - 1));
                for (int index = 0; index < Math.Min(10, m_items.Length); index++)
                {
                    Rectangle itemBounds = new Rectangle(bounds.X,
                                                         bounds.Y + bounds.Height + index * itemHeight,
                                                         m_items.Length > 10 ? bounds.Width - buttonWidth : bounds.Width,
                                                         itemHeight);
                    if (m_hightlight_index == index + m_scroll_index)
                        g.FillRectangle(new SolidBrush(SystemColors.Highlight), itemBounds);
                    g.DrawString(m_items[index + m_scroll_index], Font, BackBrush, itemBounds, StringFormat);
                }
                if (m_items.Length > 10)
                {
                    Rectangle rectangle = new Rectangle(m_drop_down_bounds.X + m_drop_down_bounds.Width - buttonWidth - 1,
                                                        m_drop_down_bounds.Y + 1,
                                                        buttonWidth,
                                                        itemHeight * 10);
                    g.FillRectangle(new SolidBrush(SystemColors.ScrollBar), rectangle);
                    rectangle = new Rectangle(m_drop_down_bounds.X + m_drop_down_bounds.Width - buttonWidth - 1,
                                              m_drop_down_bounds.Y + 1,
                                              buttonWidth,
                                              buttonHeight);
                    ControlPaint.DrawScrollButton(g, rectangle, ScrollButton.Up, m_top_scroll_button_state);
                    rectangle = new Rectangle(m_drop_down_bounds.X + m_drop_down_bounds.Width - buttonWidth - 1,
                                              m_drop_down_bounds.Y + 1 + itemHeight * 10 - buttonHeight,
                                              buttonWidth,
                                              buttonHeight);
                    ControlPaint.DrawScrollButton(g, rectangle, ScrollButton.Down, m_bottom_scroll_button_state);
                    int height = (int)((itemHeight * 10 - 2 * buttonHeight) * 10.0 / m_items.Length);
                    int y = m_drop_down_bounds.Y + 1 + buttonHeight +
                            (int)((itemHeight * 10 - 2 * buttonHeight) * m_scroll_index / m_items.Length);
                    rectangle = new Rectangle(m_drop_down_bounds.X + m_drop_down_bounds.Width - buttonWidth - 1,
                                              y,
                                              buttonWidth,
                                              height);
                    ControlPaint.DrawButton(g, rectangle, ButtonState.Normal);
                }
            }
        }
        protected int GetItemHeight(Graphics g)
        {
            return (int)g.MeasureString(" ", Font).Height;
        }
    }
