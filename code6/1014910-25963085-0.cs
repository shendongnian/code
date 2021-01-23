    Random R = new Random();
    void RUN()
    {
        int N = R.Next(2);
        Action[] A = new Action[2];
        A[0] = new Action(Normal);
        A[1] = new Action(Specific);
    
        A[N].Invoke();
    }
    
    private void Specific()
    {
        RUN();
    }
    
    private void Normal()
    {
        MessageBox.Show("OK");
    }
