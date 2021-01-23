       var myQa = QA.OrderBy(c=> rnd.Next()).Select(c=>new {c.Key, c.Value}).ToList();
    
       Button1.Text = myQa[0].Key;
       Button1.Tag = myQa[0].Value
       Button2.Text = myQa[1].Key;
       Button2.Tag = myQa[1].Value;
       Button3.Text = myQa[2].Key;
       Button3.Tag = myQa[2].Value;
       Button4.Text = myQa[3].Key;
       Button4.Tag = myQa[3].Value;
