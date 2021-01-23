    var result = northwind.Products
         .Where("CategoryID = 3 AND UnitPrice > 3")
         .OrderBy("SupplierID");
===
    private object bindingSourceTbl1_DataSourceBinding(object sender, EventArgs e,Expression whereClause)
    {
        using (SampleDbEntities dbo = new SampleDbEntities())
        {
             var q = from x in dbo.Tbl1
                 where x.Id == (int)comboBoxPerson.SelectedValue && whereClause
                 select x);
             q = q.Where(whereClause)// your must reference dynamic linq library.
                                     //whereClause is expression
                   .Take(100);
             return q.ToList();
           
        }
