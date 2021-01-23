    private void button3_Click(object sender, EventArgs e)
    {  
        var stopwatch = Stopwatch.StartNew();
        for (int index = 1; index < timeNum; index++)
        {
            //stopwatch.Restart(); // as they say, you don't need this
            //MessageBox.Show(“test”);
            Thread.Sleep(5000);  
            pictureBox1.Image = list1[index * 2];
            pictureBox2.Image = list1[index * 2 + 1];
            //stopwatch.Stop();
            pictureBox1.Update();
            pictureBox2.Update();
        }
    }
