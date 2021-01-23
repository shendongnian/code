    List<double> doubleList = new List<double>(new double[]
        {
            12345,
            1234.5,
            123.45,
            12.345,
            1.2345,
            1.2,
            1.23,
            1.234,
            1.2345,
            12.3,
            123.4,
        });
    private void button1_Click(object sender, EventArgs e)
    {
        foreach (var x in doubleList)
        {
            bool isNum = Regex.IsMatch(x.ToString(), @"^\-{0,1}\d+(.\d+){0,1}$");
            int countOfDot = Regex.Matches(x.ToString(), @"\.").Count;
            if (countOfDot == 1 && isNum) //number w/ decimal place
            {
                string[] spLitX = x.ToString().Split('.');
                if (spLitX[1].Count() <= 5) //float max of 5digits
                {
                    Console.WriteLine(x);
                }
            }
            else if (countOfDot == 0 && isNum) //number w/o decimal place
            {
                Console.WriteLine(x);
            }
            else
            {
                //do nothing . . .
            }
        }
    }
