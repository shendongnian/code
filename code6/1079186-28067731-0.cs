    --- Example:
    public class Torder
    {
       public int Id {get;set;}
       public string Name {get;set;}
    }
    
    [HttpPost]
        public ActionResult Insert(Torder Model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    ntity.Torders.Add(Model);
                    ntity.SaveChanges();
                    ModelState.Clear();
                    TempData["notice"] = "Successfully registered";
                }
                catch(Exception ex)
                {
                    TempData["Failure"] = ex;
                }
            }
            else
            {
                TempData["Failure"] = "Record Not Saved";
            }
    
            //var empoyees = Employee.GetList();
    
            List<Torder> model1 = GetProducts();
    
            return View(model1);
        }
        public List<Torder> GetProducts()
        {
            List<Torder> objStudent = new List<Torder>();
            // your logic
            return objStudent;
        }
    
    ---------
    Page:
    -------------
    //html code
    @model  List<Torder>
    @foreach(Torder order in Model)
    {
    // here you can build you grid(table) 
    order.Name
    order.Id
    }
