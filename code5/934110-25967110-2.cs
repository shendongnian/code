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
                }) { };
    
            private void button1_Click(object sender, EventArgs e)
            {
                foreach (var x in doubleList)
                {
                    int countNumber = Regex.Matches(x.ToString(), @"[0-9]").Count; //count all numbers in a string ...
                    bool containsDot = x.ToString().Contains("."); //even w/o this validation it will work ;
    
                    if (containsDot && countNumber == 5) //contains "." and 5digit
                    {
                        Console.WriteLine(x);
                    }
                    else if (!containsDot && countNumber == 5) //not contains "." and 5digit
                    {
                        Console.WriteLine(x);
                    }
                    else
                    {
                       //do nothing . . .
                    }
                }
            }
