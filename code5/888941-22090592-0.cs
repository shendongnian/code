    public void Add(ExaminationDomain domain, IPrincipal principal)
    {
        Examination newExam = Mapper.Map<ExaminationDomain, Examination>(domain);
        newExam.AuthorId = principal.Identity.GetUserId();
        newExam.CreatedBy = principal.Identity.Name;
        newExam.CreatedDate = DateTime.Now;
        context.Examinations.Add(newExam);
        context.SaveChanges();
    }
