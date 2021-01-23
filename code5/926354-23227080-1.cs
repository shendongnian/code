    List<int> list = new List<int>(); //defined at class level
    private void button1_Click(object sender, EventArgs e)
    {
        Random rnd = new Random();
        int randnum = rnd.Next(1, 49); // creates a number between 1 and 49
        if (!list.Contains(randnum))
        {
            list.Add(randnum);
        }
        else
        {
            //duplicate number
        }
        MessageBox.Show(Convert.ToString(randnum));
    }
