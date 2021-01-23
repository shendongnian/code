        private void RadPageView1_MouseMove(object sender, MouseEventArgs e)
        {
            RadPageViewItem hoveredItem = radPageView1.ElementTree.GetElementAtPoint(e.Location) as RadPageViewItem;
            if (hoveredItem != null)
            {
                radPageView1.SelectedPage = hoveredItem.Page;
            }
        }
