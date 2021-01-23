    using System.Linq;
    public Course GetCourseByCourseID(string id)
    {
         return CourseArray.Where(a => a.CourseID == id).First();
    }
