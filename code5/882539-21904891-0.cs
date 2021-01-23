    public class QualificationViewModel
    {    
       public Qualification _Qualification {get; set;}
    //public Subject _Subject;
    //public FeeScheme _FeeScheme;
    }
    [HttpGet]
    public ActionResult CreateNewQualification()
    {
        var Model = new QualificationViewModel();
        return PartialView("PartialQualification_Create",model);
    }
