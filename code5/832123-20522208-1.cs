    [Route("/Courses", "GET"), UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class ListCoursesRequest : IReturn<List<CourseResult>> {}
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class CoursesService : Service {
        public List<CourseResult> Get(ListCoursesRequest request) { }
    }
