    //check to see if they answered if they are public practice attorney
               string pp = Convert.ToString(collection["PublicPractice"]);
               if (pp == "noAnswer")
               {
                   TempData["ClassSelected"] = cs;
                   TempData["PPerror"] = "Sorry, but you did not answer...";
                   return RedirectToAction("Register", "ClassList", new { id = cs });
               }
