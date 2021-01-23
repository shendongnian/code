    delegate void SetTextCallback(string text);
    delegate void clear_gvTaskCasesCallback(bool clearIt);
    delegate void remove_gvTaskCasesDSCallback( bool removeDS);
    private void removeGridDS(bool removeDS)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.gvTaskCases.InvokeRequired)
            {
            remove_gvTaskCasesDSCallback d = new remove_gvTaskCasesDSCallback(removeGridDS);
            this.Invoke(d, new object[] { removeDS });
            }
            else
            {
                if (this.gvTaskCases.DataSource !=null)
                {
                this.gvTaskCases.DataSource=null;
                }
            }
        }
        private void clear_gvTaskCases(bool clearIt)
        {
        // InvokeRequired required compares the thread ID of the
        // calling thread to the thread ID of the creating thread.
        // If these threads are different, it returns true.
        if (this.gvTaskCases.InvokeRequired)
        {
            clear_gvTaskCasesCallback d = new clear_gvTaskCasesCallback(clear_gvTaskCases);
            this.Invoke(d, new object[] { clearIt });
            }
            else
            {
            if (this.gvTaskCases.Rows.Count != 0)
            {
            this.gvTaskCases.Rows.Clear();
            }
        }
    }
        
