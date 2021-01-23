    [HttpPost]
    public ActionResult Create(MemoCreateViewModel model) {
        if(!ModelState.IsValid)
            return RedirectToAction("Create");
        Guid employeeId;
        List<Guid> employeeIds = new List<Guid>();
        foreach (var id in model.SelectedEmployeeIds) {
            if (!Guid.TryParse(id, out employeeId)) {
                continue;
            }
            employeeIds.Add(employeeId);
        }
        EFDbContext dbContext = new EFDbContext();//Note
        var employees = _employeeRepository.GetEmployeesByIds(dbContext, employeeIds);//Note the extra parameter
        model.Memo.Employees = employees.ToList<Employee>();
        _memoRepository.SaveMemo(dbContext,model.Memo);//Note the extra parameter
        return RedirectToAction("List");
    }
