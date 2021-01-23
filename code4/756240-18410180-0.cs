    //using (StreamWriter sw1 = new StreamWriter("DataNames.txt"))
    //{
    //   sw1.WriteLine(textBox1.Text);
    //}
    System.IO.File.AppendAllText("DataNames.txt", textBox1.Text);
