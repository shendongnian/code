    public ActionResult Edit(int projectId)
    {
        using(var context = new CustomDbContext())
        {
            var model = new ActorsViewModel()
            {
                projectName = context.Projects.FirstOrDefault(p => p.Id = projectId).Name,
                projectactors = context.Actors.Where(a => a.ProjectId == projectId).ToList()
            }
        }
        return View(model);
    }
