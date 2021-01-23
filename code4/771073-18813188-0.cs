    private void waits(TextBox t1 ,TextBox t2)
    {
        t1.Invoke(new Action(()=>
        {
            t1.BackColor = Color.Red;
        });
        t2.Invoke(new Action(()=>
            t2.BackColor =  Color.Red;
        });
    }
