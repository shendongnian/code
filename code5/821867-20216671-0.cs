    [HttpPost]
    public JsonResult SaveSubjectInfo(PreviousExamSubject previousExamSubject)
    {
        List<PreviousExamSubject> list= (List<PreviousExamSubject>) Session["myitem"] ?? new List<PreviousExamSubject>();
        list.Add(previousExamSubject);
        Session["myitem"] = list;
        return Json(JsonRequestBehavior.AllowGet);
    }
