    Entities ent = new Entities();//This is my dbcontext object
    //First i will query the db to get the query stored in table
    Query query = ent.Queries.FirstOrDefault();
    string sql = query.Query;//I have assigned the query to a string and now i will execute this
            
    //Here i run the query in db against the table employee you need to change this to products.
    var list = ent.Employees.SqlQuery(sql).ToList<Employee>();        
    //Create List of SelectListItem
    List<SelectListItem> selectlist = new List<SelectListItem>();
    foreach (Employee emp in list)
    {
     //Adding every record to list  
     selectlist.Add(new SelectListItem { Text = emp.Name, Value = emp.Id.ToString() });
    }
    
    ViewBag.SelectList = selectlist;//Assign list to ViewBag will access this in view
    return View(list);
