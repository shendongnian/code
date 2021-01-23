     public class recController : Controller
        {
            // GET: rec
            string firstname = "";
            string lastname = "";
    
            List<string> myList = new List<string>();
    
            public ActionResult recieveData(FormCollection fc)
            {
              //Recieve a posted form's values from  parameter fc
                firstname = fc[0].ToString(); //user
                lastname = fc[1].ToString();  //pass
    
               //optional: add these values to List
                myList.Add(firstname);
                myList.Add(lastname);
    
                //Importan:
                //These 2 values will be return with the below view
                //using ViewData[""]object...
                ViewData["Username"] = myList[0];
                ViewData["Password"] = myList[1];
    
                //let's Invoke view named rec.cshtml
                // Optionaly we will pass myList to the view
                // as object-model parameter, it will still work without it thought
                return View("rec",myList);
            }
        }
