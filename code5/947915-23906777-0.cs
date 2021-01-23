        private void button1_Click(object sender, EventArgs e)
        {
            // create a long list to force scrollbar
            List<String> tempList = new List<string> { "1 value", "1 value", "1 value", "1 value", "1 value", "1 value", "1 value", "1 value", "1 value", "1 value", "1 value", "1 value", "1 value" };
            gridControl1.DataSource = tempList;
            // check if scrollbar is visible
            GridViewInfo viewInfo = gridView1.GetViewInfo() as GridViewInfo;
            if (viewInfo != null)
            {
                // check if scrollbar
                if (viewInfo.VScrollBarPresence == ScrollBarPresence.Visible)
                {
                    Console.WriteLine("Scrollbar visible");
                }
                else
                {
                    Console.WriteLine("Scrollbar not visible");
                }
            }
        }
