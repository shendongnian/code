        int ii = 0;
        int i = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            ii = LstBxTaskList.Items.Count;
            if (i == ii)
            {
                i = 0;
                LstBxTaskList.SelectedIndex = 0;
            }
            LstBxTaskList.SelectedIndex = i;
            i++;
            LstBxTaskList.DrawMode = DrawMode.OwnerDrawFixed;
        }
        void LstBxTaskList_DrawItem1(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            int itemIndex = e.Index;
            if (itemIndex >= 0 && itemIndex < LstBxTaskList.Items.Count)
            {
                Graphics g = e.Graphics;
                // Background Color
                SolidBrush backgroundColorBrush = new SolidBrush((isItemSelected) ? Color.CornflowerBlue : Color.White);
                g.FillRectangle(backgroundColorBrush, e.Bounds);
                // Set text color
                string itemText = LstBxTaskList.Items[itemIndex].ToString();
                SolidBrush itemTextColorBrush = (isItemSelected) ? new SolidBrush(Color.White) : new SolidBrush(Color.Black);
                g.DrawString(itemText, e.Font, itemTextColorBrush, LstBxTaskList.GetItemRectangle(itemIndex).Location);
                // Clean up
                backgroundColorBrush.Dispose();
                itemTextColorBrush.Dispose();
            }
            e.DrawFocusRectangle();
        }
        void LstBxTaskList_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            int itemIndex = e.Index;
            if (itemIndex >= 0 && itemIndex < LstBxTaskList.Items.Count)
            {
                Graphics g = e.Graphics;
                // Background Color
                SolidBrush backgroundColorBrush = new SolidBrush((isItemSelected) ? Color.White : Color.White);
                g.FillRectangle(backgroundColorBrush, e.Bounds);
                // Set text color
                string itemText = LstBxTaskList.Items[itemIndex].ToString();
                SolidBrush itemTextColorBrush = (isItemSelected) ? new SolidBrush(Color.Black) : new SolidBrush(Color.Black);
                g.DrawString(itemText, e.Font, itemTextColorBrush, LstBxTaskList.GetItemRectangle(itemIndex).Location);
                // Clean up
                backgroundColorBrush.Dispose();
                itemTextColorBrush.Dispose();
            }
            e.DrawFocusRectangle();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            LstBxTaskList.DrawItem += new DrawItemEventHandler(LstBxTaskList_DrawItem);
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            LstBxTaskList.DrawItem +=new DrawItemEventHandler(LstBxTaskList_DrawItem1);
        }
