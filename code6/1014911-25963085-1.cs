    Random R = new Random();
    void RUN()
    {
        int N = R.Next(2);
        Action[] A = new Action[2];
        A[0] = new Action(Act1);
        A[1] = new Action(Act2);
    
        A[N].Invoke();
    }
    
    private void Act2()
    {
        MessageBox.Show("Cancel");
    }
    
    private void Act1()
    {
        MessageBox.Show("OK");
    }
