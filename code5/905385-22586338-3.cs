    private void button1_Click(object sender, EventArgs e)
        {
            tbxA.Clear();
            tbxB.Clear();
    
            int[] number = new int[6];
            Random m = new Random();
            while(true)
            {
                for (int i = 0; i < 6; i++)
                {
                    number[i] = m.Next(0, 4);
                    tbxA.AppendText(number[i].ToString() + Environment.NewLine);
                    //tbxA.AppendText("" + Convert.ToString(number[i]) + "\n");
                }
    
                int sum = number.Sum();
                if (sum > 8)
                {
                    tbxB.AppendText(" " + sum);
                    break;
                }
                else{
                    tbxA.Clear();
                    tbxB.Clear()
                }
            }
        }
