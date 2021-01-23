    var Ma = context.PAFs
                    .Where(b => b.PostCode == txtaddrss.Text)
                    .Select(b => new { b.GhouseNo, b.Eroad, b.City }).ToList();
    foreach (string name in Ma)
    {
      listBox1.Items.Add(name.GhouseNo + ", " + name.Eroad + ", " + name.City);
    }
