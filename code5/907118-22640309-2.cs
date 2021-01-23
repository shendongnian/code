     public static void  Proc()
    {
        Form2 Child; 
        Application.Run(new Form2());
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(Proc));
        t.Start();
        this.Close();
     }
