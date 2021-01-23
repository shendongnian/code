    dataContext ctx = new dataContext(); // your data context
      
    [DirectMethod]
    public void DeleteSelected(int[] idArray)
    {
        ctx.Employees.DeleteAllOnSubmit(
            ctx.Employees.Where(x => idArray.Contains(x.id)).ToArray()
        );
        ctx.SubmitChanges();
    }
