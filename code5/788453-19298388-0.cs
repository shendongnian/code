        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (GetSelectedIndex(this.tabControlDbSwitch) == 0)
            {
                Console.WriteLine("Success!");
            }
        }
        private delegate int ReturnSelectedIndex(TabControl tb);
        private int GetSelectedIndex(TabControl tb)
        {
            if (tb.InvokeRequired)
            {
                return (int)tb.Invoke(new ReturnSelectedIndex(GetSelectedIndex), new Object[] { tb });
            }
            else
            {
                return tb.SelectedIndex;
            }
        }
