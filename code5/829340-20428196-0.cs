    [HttpPost]
    public ActionResult CreateTask(tblTask newTask)
    {
        var TaskCollection = new List<tblTask>();
        //Check whether the collection exist in session, If yes read it
       // & cast it to the tblTask collection & set it to the TaskCollection variable
        if (Session["TaskCollection"] != null)
        {
            TaskCollection= (List<tblTask>) Session["TaskCollection"];           
        }
        if(newTask!=null)
           TaskCollection.Add(newTask);
        //Set the updated collection back to the session
        Session["TaskCollection"] = TaskCollection;
        return RedirectToAction("Index");
    }
