     private void button1_Click(object sender, EventArgs e)
        {
            var c = new Clock();
            c.NewDay += OnNewDay;
        }
     private void OnNewDay(object sender, EventArgs e)
        {
            // new day comes
        }
