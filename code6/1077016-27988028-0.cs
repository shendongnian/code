    public partial class Course_Services
    {
        #region Process All Courses Application's URL
        public List<CourseInstanceModel> ProcessAllCoursesApplicationURL(CourseApplicationsURLFeed_Model _obj)
        {
           
            //get all the courses which have Application URL is Null..
            using(var _uof = new Courses_UnitOfWork())
            {
              var  ListOfCoursesInstances = _uof.CourseInstances_Repository.GetAll();
              var _listOfCoursesWithoutURL = (from b in ListOfCoursesInstances 
                                               where b.ApplicationURL == null
                                               select b).ToList();
              return _listOfCoursesWithoutURL;
            }
        }
        #endregion
    }
