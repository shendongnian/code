    public void DisplayMessage()
    {
       using ( Entities ctx = new Entities())
        {
            var query = from e in ctx.EMPLOYEES select new {  e.EMPLOYEE_ID,e.FIRST_NAME,
                         e.LAST_NAME, e.EMAIL, e.PHONE_NUMBER,
                         e.SALARY, e.DEPARTMENT_ID};
         var results = query.ToList();
         gridview.DataSource = results;
         gridview.Databind();
        }
    }
