    public class SomeController
    {
        private StudentsRepository _repository;
        public ActionResult SomeAction()
        {
            var students = _repository.LoadStudents();
            var model = new StudentsViewModel
            {
                Males = students.Where(s => s.Gender == Gender.Male),
                Females = students.Where( s => s.Gender == Gender.Female)
            };
            return View(model);
        }
    }
