    private void button1_Click(object sender, EventArgs e)
    {
        var ary = new[]
        {
            "Color1       | Machine 1     | Pass 1 ",
            "Color2       | Machine 2     | Pass 1 ",
            "Color3       | Machine 1     | Pass 1 ",
            "Color4       | Machine 1     | Pass 2 ",
            "Color5       | Machine 2     | Pass 1 ",
            "Color6       | Machine 2     | Pass 2 "
        };
        var seprated = from x in ary.Select(x => x.Split('|'))
                        select new
                        {
                            key = x[1].Trim() + "&" + x[2].Trim(),
                            value = x[0]
                        };
        var sb = new StringBuilder();
        foreach (var key in seprated.Select(x => x.key).Distinct())
        {
            var colors = seprated.Where(x => x.key == key).Select(x => x.value.Trim()).ToArray();
            sb.AppendLine(string.Format("{0} for {1}", string.Join("/", colors), key));
        }
        textBox1.Text = sb.ToString();
    }
