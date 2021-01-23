    public class MyModel
    {
       public MyModel()
        {
            this.myDDLList = new List<SelectListItem>();
        }   
        public List<SelectListItem> myDDLList { get; set; }
        public int ddlID { get; set; }
    } 
    public ActionResult Index()
        {
            MyModel model = new MyModel();          
            using (YourEntities context = new YourEntities())
            {
                var list = context.YourTable.ToList();                 
                
                foreach (var item in list)
                {
                    model.myDDLList.Add(new SelectListItem() { Text = item.NameField, Value = item.ValueField.ToString() });
                }              
            }
            return View(model);
        }
    @Html.DropDownListFor(x => x.ddlID, Model.myDDLList)
