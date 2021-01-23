    [HttpPost]
     public ActionResult Send(string usr, string rcv, string txt)
        {
    
    
            return Content(txt);
        }
