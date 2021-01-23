        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
            datadir = ConfigurationManager.AppSettings["datadir"];
            //datadirectory defined in Web.config
            //also possible to hardcode it here, example: "c:/windows/PDFfolder"
            wkhtmltopdf = ConfigurationManager.AppSettings["wkhtmltopdf"];
            //directory to the file "wkhtmltopdf", downloaded it somewhere
            //just like above, defined at web.config possible to hardcode it in
            ViewData["IsModelValid"] = ModelState.IsValid ? "true" : "false";
            //valid checker
            if (ModelState.IsValid)      //check if valid
            {                
            db.People.Add(person);       //add to db
                
                db.SaveChanges();
            var fileContents1 = System.IO.File.ReadAllText(datadir + "Template.html"); 
            //get template from datadirectory
            fileContents1 = fileContents1.Replace("#NAME#", person.Name);
            //replace '#NAME#' by the name from the database table person.Name
           System.IO.File.WriteAllText(datadir + "tmp\\Template." + person.ID + ".html", fileContents1);
           //create a new html page with the replaced text
           //name of the file equals the ID of the person
                var pdf1 = new ProcessStartInfo(wkhtmltopdf); //start process wkhtmltopdf
                pdf1.CreateNoWindow = true;  //don't create a window
                pdf1.UseShellExecute = false; //don't use a shell
                pdf1.WorkingDirectory = datadir + "tmp\\"; //where to create the pdf
                pdf1.Arguments = "-q -n --disable-smart-shrinking Overeenkomst." + person.ID + ".html Overeenkomst." + person.ID + ".pdf";
              //get the html to convert and make a pdf with the same name in the same directory
            }
            return View(person);
        }
