    [HttpPost] 
    public ActionResult Pagina_Details(FormCollection Form,ModelClassName ModelClassObject)
    {
    if(Form["CommandBtn1"]!=null)
    {
    /// Write code for Opslaan (Edit Code)
    }
    if(Form["CommandBtn2"]!=null)
    {
    /// Write code for Verwijderen (Delete Code)
    }
    return View();
    } 
