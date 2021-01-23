       public class LayoutController : Controller
        {
            public ActionResult _TopMenu()
            {
                IList<string> menuModel = GetFromDb();
                string menu = "<ul>";
                foreach(string x in menuModel)
                {
                    menu +="<li><a href='"+x+"'>+x+"</a></li>";
                }
                menu+="</ul>";
                return Content(menu);
            }
       }
    
