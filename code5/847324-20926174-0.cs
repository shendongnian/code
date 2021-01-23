        using (var ctx = new AefesaEntities1())
        {
            dataGridView1.DataSource = ctx.Productos
                .Select( p => new { id = p.ID, whatever = p.Whatever, lazy = p.Lazy1, etc. }
                .ToList();
        }
