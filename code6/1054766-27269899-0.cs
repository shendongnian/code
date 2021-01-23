    public Form1(Form2 form2)
    {
        pform2 = form2;
    }
    
    Form2 pform2;
    private void button2_Click(object sender, EventArgs e)
    {
        if (form2 != null)
        {
            pform2.Show();
        }
        else
        {
            pform2 = new Form2(this);
            pform2.Show();
            this.Hide();
        }
        this.Hide();
    }
    
    // form2
    
    public Form2(Form1 form1)
    {
        pform1 = form1;
    }
    
    Form1 pform1;
    private void button1_Click(object sender, EventArgs e)
    {
    
        if (form1 != null)
        {
            pform1.Show();
        }
        else
        {
            pform1 = new Form1(this);
            pform1.Show();
            this.Hide();
        }
        this.Hide();
    }
