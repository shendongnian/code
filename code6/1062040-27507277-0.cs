    public class Student
    {
        //Student memebers here
    }
    public class StudentViewModel
    {
        public ObservableCollection<Student> Students { get; set; }
        public StudentViewModel()
        {
            this.Students = new ObservableCollection<Student>();
            //Call some method to load all students into the collection.
        }
        ...
    }
