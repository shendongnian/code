    // Now it can be accessed throughout the class. 
    // Note that I've called it "_eachVar" to follow the naming convention for 
    // fields in a class. 
    private int _eachVar = 0; 
    private void Set1_Click(object sender, EventArgs e)
    {
        if (PAT.Text != "" && Loading1.Value != 100 && Loading1.Value - 100 <= 0)
        {
        _eachVar = Convert.ToInt32(PAT.Text); //The Var 'EachVar'
        label1.Text = "Value: " + Convert.ToString(EachVar);
        }
    }
    private void Start_Click(object sender, EventArgs e)
    {
        if (Loading1.Value + _eachVar < 100) // The Error
        {
            Timer1.Start();
            Timer1.Interval = 1000;
        }
        else
        {
            Loading1.Value = 100;
            Timer1.Stop();
        }
    }
