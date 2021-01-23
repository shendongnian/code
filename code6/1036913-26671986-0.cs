    public class StudentsController : ApiController
    {
        [HttpPost]
        public StudentResult StudentStatus([FromBody]InComingStudent inComingStudent)
        {
            ProcessStudent po = new ProcessStudent();
            StudentResult studentResult = po.ProcessStudent();
            return StudentResult;
        }
    }
