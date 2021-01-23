    public ActionResult MYsample()
    {
        var MyList = storeDB.GenreList();
        var a= MyList.Count;
        if (a != null)
        {
            foreach (var li in MyList)
            {
                return File(li.fileContent, li.mimeType,li.fileName);
            }
        }
        return View(MyList);
    }
