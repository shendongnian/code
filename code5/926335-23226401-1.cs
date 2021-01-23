    private void p1_Exited(object sender, EventArgs e)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new Action(OnProcessExited));
        }
        else
        {
            OnProcessExited();
        }
    }
    private void OnProcessExited()
    {
        Form3 f3 = new Form3();
        f3.Show();
        this.Hide();
    }
