    public Student
    {
       private _Courses = new List<Course>();
    
       public int ID { get; set; }
    
       public virtual ICollection Courses 
       {
          get { return _Courses; }
          protected set { _Courses = value; }
       }
    
       public void AddCourse(Course course)
       {
          //And you can add your duplicate check here
          if(!Courses.Any(c => c.ID == course.ID))
             Courses.Add(course);
       }
    }
