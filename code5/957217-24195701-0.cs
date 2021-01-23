    public ActionResult DescargaCsv() {  
        // do stuff
        if (status != 0){
            return new HttpStatusCodeResult(500, "This is a bad status message");
        } else{
            //do other stuff, this is OK
        }
    }
