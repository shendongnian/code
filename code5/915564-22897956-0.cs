        public ActionResult Index()
        {
            professionalContext = new ProfessionalContext();
            var professionals = professionalContext.GetAllProfessionals();
            Debug.Assert(professionals != null && professionals.Any());
            if (professionals == null)
            {
                return HttpNotFound();
            }
            return View(professionals);
        }
