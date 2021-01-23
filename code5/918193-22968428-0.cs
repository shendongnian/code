    private void button1_Click(object sender, EventArgs e)
    {
        listTest=new List<int>();
        intTest = int.Parse(textBox1.Text); // Will be a value between 1 and 9 in my code)
        for (int i = 0; i < intTest; i++)
        {
            int temp = methodRandom();
           
            listTest.Add(temp);
        }
    }
