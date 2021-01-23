        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(StudentInfo model)
        {
            var personalInfo = model.PersonalInfo;
            var educationQualification = model.EducationalQualification;
            using (var context = new StudentDbContext())
            {
                context.StudentPersonalInfos.Add(personalInfo);
                context.EducationQualifications.Add(educationQualification);
                context.SaveChanges();
            }
            return View();
        }
