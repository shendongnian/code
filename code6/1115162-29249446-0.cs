            Random ran = new Random();
            for (var x = 0; x <= 23; x++)
            {
                listBox1.Items.Add(Convert.ToString(ran.Next(0, 100)));
            }
            var number = listBox1.Items.Cast<string>().Select(Int32.Parse).Sum();
            var count = listBox1.Items.Count;
