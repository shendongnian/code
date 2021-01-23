    public ActionResult Index()
    {
        IEnumerable<MyViewModel> viewModel = null;
        using (MyDBContext dB = new MyDBContext())
        {
            viewModel = (from st in dB.Students
                        join d in dB.Departments on st.DepartmentID equals d.DepartmentID
                        join g in dB.Genders on st.GenderID equals g.GenderID
                        select new MyViewModel
                        {
                            StudentID= st.StudentID,
                            StudentName = st.StudentName,
                            Gender = g.GenderName,
                            DepartName = d.DepartmentName
                        }).ToList();
        }
        return View(viewModel);
    }
