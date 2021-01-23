    private void Form1_Load(object sender, EventArgs e)
    {
        using (winappContext _context = new winappContext())
        {
            var query = from c in _context.Customers
                        orderby c.CustomerName
                        select c;
            this.customerBindingSource.DataSource = query.ToList();
        }
    }
