public ActionResult Index()
{
  //code to populate your model1 and model2 already assumed
  var viewModels = (from m in model1List
                 join r in model2List on m.CoachId equals r.CoachId 
                 select new StudentCoachViewModel(){ StudentName=m.StudentName, 
                          CoachName = r.CoachName }).ToList();
  return View(viewModels);
}
