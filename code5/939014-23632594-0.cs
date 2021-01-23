    var result = ctx.ConsumerProducts
                    .Select(r=> new 
                    {
                        Id = r.ID, 
                        Model = r.Model,
                        Status = "Offline"
                    }).ToList();
    dataGridView1.DataSource = result;
