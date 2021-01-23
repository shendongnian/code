    public class MyListBox : ListBox
    {
        public bool DoEvents{ get; set; } // Made it public so in the future I can block event triggering externally
        public MyListBox()
        {
            DoEvents = true;
        }
        public void RefreshAllItems()
        {
            SuspendLayout();
            DoEvents = false;
            base.RefreshItems(); // this triggers OnSelectedIndexChanged as it selects the selected item again
            DoEvents = true;
            ResumeLayout();
        }
        // I only use this event but you can add all events you need to block  
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (DoEvents)
                base.OnSelectedIndexChanged(e);
        }
    }
