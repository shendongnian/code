    [HttpPost]
    public ActionResult Index(string searchString){
        searchString = searchString.Replace(",", ".");
  
        if (!String.IsNullOrEmpty(searchString)){
            students = students.Where(s => s.FIRST_NAME.Contains(searchString) 
            || s.LAST_NAME.Contains(searchString)
            || s.PERSONAL_NUMBER.Contains(searchString)
            || s.ACD_UNI_DEGREES.DEGREE.Contains(searchString)
            || s.ACD_UNI_FACULTIES.FACULTY.Contains(searchString)
            || s.ACD_UNI_SPECIALIZATIONS.SPECIALIZATION.Contains(searchString)
            || (s.SEMESTER.ToString()).Contains(searchString) 
            || s.COR_PAYER_STATUS.NAME.Contains(searchString)
            || SqlFunctions.StringConvert(s.CREDIT_COUNT).Contains(searchString));
        }
        return View(students.ToList());
    }
You are casting the decimal to string normally with ToString(). However the bracetts are the magic weapon here:
(s.SEMESTER.ToString())
