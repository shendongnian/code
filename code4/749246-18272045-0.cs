    Func<entityContex, IQueryable</*Table1 type*/>> queryExecutor = null;
    
    private void SearchMethod()
    {
       using(var ctx = new entityContex())
       {
          queryExecutor = c => c.Table1.Where(t=> t.Name.StartWith(txtName.Text)).Take(100);
          var qry = queryExecutor(ctx);
    
          dgvResult.DataSource = qry.ToList();
       }
    }
    
    private void RefreshResult()
    {
       using(var ctx = new entityContex())
       {
          if(queryExecutor != null)
          dgvResult.DataSource = queryExecutor(ctx).ToList();
       }
    }
