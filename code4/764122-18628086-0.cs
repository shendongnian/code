    public static int CalcProg(int userGoal, int userBalance, int userProg)
    {
        userProg = userBalance / userGoal;
        userProg = userProg * 100
        return userProg;
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        //Calls the FileVerification Method
        FileVerification();
        //Sets the label1 transparency to true
        label1.Parent = pictureBox1;
        label1.BackColor = Color.Transparent;
        LoadData();
        
        progressBar1.Value = CalcProg(userGoal, userBalance, userProg);
        progLabel = Convert.ToString(userProg);
        label3.Text = progLabel;
    }
