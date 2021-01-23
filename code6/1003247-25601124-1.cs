    public ActionResult Report(int id)
    {
        ViewBag.Id =id;
        var model=new YourViewModel()
        return new RazorPDF.PdfResult(model, "Report");
    } 
