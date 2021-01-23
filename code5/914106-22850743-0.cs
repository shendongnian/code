    public JsonResult MyAction()
    {
        return Json(
            new
            {
                E = "Letter E",
                F = "Letter F",
                G = "Letter G",
                Selected = "F",
            });
    } 
