    private bool loop = false;
    
    private void Start()
    {
        loop = true;
        Spam("Some Message??");
    }
    
    private void Spam(string message)
    {
        while (loop)
        {
            MessageBox.Show("This API is not original"); 
        }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        loop = true;
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        loop = false;
    }
