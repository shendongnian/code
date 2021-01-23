    private void run(string data) {
    
        //if (this.labelO2.InvokeRequired)
        //{
        //    SetRichBoxCallBack d = new SetRichBoxCallBack(run);
        //    this.Invoke(d, new object[] { data });
        //}
        //else {
        //    labelO2.Text = data;
        //}
        this.Invoke(new MethodInvoker(delegate {labelO2.Text = data;}));
    
    }
