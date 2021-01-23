    public class MyViewModel
    {
        public int? Id { get; set; }
        
        //Other properties here
    }
     public ActionResult Page(int? id)
     {
         var myViewModel = new MyViewModel()
         {
             Id = id
         };
         return View(myViewModel);
     }
