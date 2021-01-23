    int Test()
    {
        throw new InvalidOperationException("Surpise from the UI thread!");
    }
    void Form_Load(object sender, EventArgs e)
    {
        // UI thread
        ThreadPool.QueueUserWorkItem(x =>
        {
            // pool thread
            try
            {
                this.Invoke((MethodInvoker)Test);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        });
    }
