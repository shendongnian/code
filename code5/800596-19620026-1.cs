    public void DoThisAllTheTime()
    {
        while(!_stopCounting)
        {
            number += 1;
            MethodInvoker yolo = delegate() { label1.Text = number.ToString(); };
            this.Invoke(yolo);
        }
    }
 
