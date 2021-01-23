    public class AssessorsViewModel
    {
        [LimitCount(3, 7, ErrorMessage = "whatever"]
        List<Assessor> Assessors { get; set; }
    }
