     List<Record> Records = new List<Record>();
                Records.Add(new Record { Answer = 5, Date = DateTime.Parse("02/02/2015"), User = "Harry", Question = "What is..?" });
                Records.Add(new Record { Answer = 4, Date = DateTime.Parse("02/02/2015"), User = "Harry", Question = "How is..?" });
                Records.Add(new Record { Answer = 3, Date = DateTime.Parse("02/03/2015"), User = "Alice", Question = "What is..?" });
                Records.Add(new Record { Answer = 1, Date = DateTime.Parse("02/03/2015"), User = "Alice", Question = "How is..?" });
        
            var Result = Records.GroupBy(r => new { r.Date, r.User })
                .Select(g => new
                {
                    Date = g.Key.Date,
                    User = g.Key.User,
                    WhatIs = g.Where(i => i.Question == "What is..?")
                        .Where(i => i.User == g.Key.User).Select(i => i.Answer).First(),
                    HowIs = g.Where(i => i.Question == "How is..?")
                        .Where(i => i.User == g.Key.User).Select(i => i.Answer).First()
                }).ToList();
            dataGridView1.DataSource = Result;
