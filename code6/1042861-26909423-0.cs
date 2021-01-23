    public claa AAA
    {
        private enum ButtonClicked {Left, Middle, Right};
        private ButtonClicked m_oMouseButtonClicked;
        private DispatcherTimer m_oTimer;
        private double m_nScrollOffset;
        private ScrollViewer m_oScrollBar;
    
        public IcuAlertGrid()
        {
            this.Initialized += IcuAlertGrid_Initialized;
            this.Loaded += IcuAlertGrid_Loaded;
            m_oTimer = new DispatcherTimer();
            m_oTimer.Tick += m_oTimer_Tick;
            m_oTimer.Interval = new TimeSpan(2500000);
        }
        void IcuAlertGrid_Initialized(object sender, EventArgs e)
        {
            setStyle0(true);
            //throw new NotImplementedException();
        }
        void IcuAlertGrid_Loaded(object sender, RoutedEventArgs e)
        {
            m_oScrollBar = GetScrollViewer(this);
        }
        void m_oTimer_Tick(object sender, EventArgs e)
        {
            if (m_oScrollBar != null)
            {
                m_oScrollBar.ScrollToVerticalOffset(m_oScrollBar.VerticalOffset + m_nScrollOffset);
            }
        }
        private void PreviewMouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                row.IsSelected = !row.IsSelected;
                m_oMouseButtonClicked = ButtonClicked.Left;
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                //row.IsSelected = !row.IsSelected;
                m_oMouseButtonClicked = ButtonClicked.Right;
            }
            row.CaptureMouse();
            row.MouseMove += row_MouseMove;
            e.Handled = true;
        }
        private void row_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridRow oRow = sender as DataGridRow;
            Point oPosFromThis = e.GetPosition(this);
            if (oPosFromThis.Y < 0)
            {
                m_nScrollOffset = -1.0;
                m_oTimer.Start();
            } 
            else if (this.ActualHeight < oPosFromThis.Y)
            {
                m_nScrollOffset = 1.0;
                m_oTimer.Start();
            } 
            else
            {
                m_oTimer.Stop();
            }
        }
        private void Row_MouseUp(object sender, MouseButtonEventArgs e)
        {
            int nStart;
            int nEnd;
            m_oTimer.Stop();
            DataGridRow row = sender as DataGridRow;
            row.ReleaseMouseCapture();
            row.MouseMove -= row_MouseMove;
            int nStartRowIndex = ItemContainerGenerator.IndexFromContainer(row);
            Point oPosFromRow = e.MouseDevice.GetPosition(row); 
            int nEndRowIndex = nStartRowIndex + (int)Math.Floor(oPosFromRow.Y / row.ActualHeight);
            if (nStartRowIndex < nEndRowIndex)
            {
                nStart = Math.Max(nStartRowIndex, 0);
                nEnd = Math.Min(nEndRowIndex, Items.Count - 1);
            }
            else
            {
                nStart = Math.Max(nEndRowIndex, 0);
                nEnd = Math.Min(nStartRowIndex, Items.Count - 1);
            }
            for (; nStart <= nEnd; ++nStart)
            {
                DataGridRow oTmp = ((DataGridRow)ItemContainerGenerator.ContainerFromIndex(nStart));
                if (m_oMouseButtonClicked == ButtonClicked.Left)
                {
                    oTmp.IsSelected = row.IsSelected;
                }
                else if (m_oMouseButtonClicked == ButtonClicked.Right)
                {
                    oTmp.IsSelected = !oTmp.IsSelected;
                }
            }
            e.Handled = true;
        }
        private static ScrollViewer GetScrollViewer(DependencyObject p_oParent) 
        {
            ScrollViewer child = default(ScrollViewer);
            int numVisuals = VisualTreeHelper.GetChildrenCount(p_oParent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(p_oParent, i);
                child = v as ScrollViewer;
                if (child == null)
                {
                    child = GetScrollViewer(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }
    }
