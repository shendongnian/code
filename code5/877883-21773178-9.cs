public ActionResult Index(int id)
{
  //code to load model1 and model2 already assumed to be in place. also assuming you loaded this data from a database by the id field being passed into this method.
  return View(new StudentCoachViewModel(){ StudentName = model1.StudentName, CoachName = model2.CoachName});
}
