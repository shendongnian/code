    int x = 0;
    int number = 0;
    int i = 0;
    Random ran = new Random();
    for (x = 0; x <= 23; x++)
    {
        listBox1.Items.Add(Convert.ToString(ran.Next(0, 100)));
    }
    while (i < listBox1.Items.Count)
    {
        number += Convert.ToInt32(listBox1.Items[i++]);
    }
            
    totaltextBox.Text = Convert.ToString(number);
    fileNumbers.Text = listBox1.Items.Count.ToString();
