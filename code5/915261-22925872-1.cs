    public ActionResult Detail(int id)
    {
        var project = Projects.Where(p = p.Id == id).FirstOrDefault();
        var prevId = projectsRepository.GetPrev(project.Id);
        var nextId = projectsRepository.GetNext(project.Id);
        var projectVM = new ProjectVM {
            Project = project,
            PrevId = prevId,
            NextId = nextId
        };
        return View(projectVM);
    }
