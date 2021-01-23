    private void button1_Click(object sender, EventArgs e)
        {   
            tbxA.Clear();
            tbxB.Clear();
    
            //int[] number = new int[6];
            List<string> number = new List<string>();
            Random m = new Random();
            while(true)
            {
                for (int i = 0; i < 6; i++)
                {
                    number.Add(m.Next(0, 4));
                }
    
                int sum = number.Sum();
                if (sum > 8)
                {
                    tbxA.AppendText(string.Join("Environment.NewLine", number.ToArray()))
                    tbxB.AppendText(" " + sum);
                    break;
                }
            }
        }
