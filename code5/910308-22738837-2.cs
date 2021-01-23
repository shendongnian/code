    public ActionResult ShowIfExists(id)
        if ( System.IO.File.Exists(@"C:\BBB\"+id) )
            return PartialView("_ShowIfExists",null,id);
        }
        return new EmptyResult();
    }
