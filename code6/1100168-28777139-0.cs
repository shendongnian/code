    for (int i = 0; i < 100000; i++)
          {
                label.Text = i;
                double s1 = rnd.NextDouble();
                double s2 = rnd.NextDouble();
                w = Math.Sqrt(-2 * Math.Log(s1)) * Math.Cos(2 * Math.PI * s2);
                listBox1.Items.Add(w.ToString());
    
           }
