    public class ViewModel 
    {
       public List<int> Melt1 { get; set; }
       public void LoadMeltProperties() 
       {
           if (Melt1 == null) 
           {
              Melt1 = new List<int>();
           }
           Melt1 = (from item in db.tbl_dppITHr
           where item.ProductionHour >= StartShift && item.ProductionHour <= EndDate
           select item).Sum(x => x.Furnace1Total).ToList();
       }
       public ViewModel Load()
       {
           LoadMeltProperties();
           return this;
       }
    }
    public ActionResult YourControllerAction() 
    {
          var vm = new ViewModel().Load();
          return View("ViewName", vm);
    }
