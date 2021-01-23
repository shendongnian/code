    public class StudentsController : ApiController
    {
        [HttpPost, Route("api/stutents/studentsstatus")]
        public StudentResult StudentStatus([FromBody]InComingStudent inComingStudent)
        {
            // ...
       }
    }
