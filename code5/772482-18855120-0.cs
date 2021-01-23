     private List<DateTime> GetRange()
     {
        var res = new List<DateTime>();
        var start = DateTime.Parse(textBox1.Text);
        var end = DateTime.Parse(textBox2.Text);
        for (var date = start; date <= end; date = date.AddDays(1))
             res.Add(date);
    
        return res;
     }
