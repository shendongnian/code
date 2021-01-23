    public class University
    {
        private readonly List<Faculty> _faculties = new List<Faculty>();
        public List<Faculty> Faculties { get { return _faculties; } }
        public Faculty CreateFaculty(string facultyName)
        {
			var faculty = new Faculty(facultyName);
            _faculties.Add(faculty);
			return faculty;
        }
        public int NumberOfFaculties { get { return _faculties.Count; } }
    }
