    List<Table1> lastQry = null;
    private void SearchMethod()
    {
     using(var ctx = new entityContex())
     {
       var qry = 
         ctx.Table1
           .Where(t=> t.Name.StartWith(txtName.Text))
           .Take(100)
           .ToList(); // <--
       lastQry = qry;
       dgvResult.DataSource = qry;
     }
    }
    private void RefreshResult()
    {
      using(var ctx = new entityContex())
      {
        if(lastQry != null)
          dgvResult.DataSource = lastQry;
      }
    }
