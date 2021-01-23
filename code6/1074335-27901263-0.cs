    @Html.DropDownListFor(m => m.VendorId,Model.Vendor)
       public class MobileViewModel 
       {          
        public List<tbInsertMobile> MobileList;
        public SelectList Vendor { get; set; }
        public int VenderID{get;set;}
       }
       [HttpPost]
       public ActionResult Action(MobileViewModel model)
       {
                var Id = model.VenderID;
