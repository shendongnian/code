    public Course GetCourseByCourseID(string id)
    {
         for(int x = 0; x < CourseArray.Length; x++)
         {
              if(CourseArray[x].CourseID == id) {return CourseArray[x];}
         }
    }
