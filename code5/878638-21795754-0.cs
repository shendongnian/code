    public ActionResult EditProgramTemplateLines(FormCollection formCollection)
    {
            for(var i=0; i< chkArrayLength; i++)
            {
               var chkId = formCollection.GetValues(i); // [1,2,3,4]
               ...
            }
    }
