        [HttpPost]
        public ActionResult CreateTask(tblTask newTask)
        {
            var TaskCollection = new List<tblTask>();
            if (Session["TaskCollection"] != null)
            {
                //Here is the line that changed -- the following line works~
                TaskCollection = (List<tblTask>)Session["TaskCollection"];
            }
            TaskCollection.Add(newTask);
            Session["TaskCollection"] = TaskCollection;
            return RedirectToAction("Index");
        }
