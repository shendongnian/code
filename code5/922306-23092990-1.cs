    private Student[][] _students; //Initialized in the constructor.
    
    private Student[] GetInnerArray(int hashCode)
    {
        int length = _students.Length; //The number of "bucketes" in the outer array.
    
        //Finds the modulus of the hashcode by the length, this lets us use an array 
        // that is smaller than int.MaxValue. If we did not do this each HashSet would 
        // take up Gigabytes of RAM.
        return _students[hashcode % length]; 
    }
    
    public Student GetStudent(Student student)
    {
        //This lookup is fast and considered "cheap"
        Student[] students = GetInnerArray(Student.GetHashCode());
    
        //This loop is slow and considered "expensive" but we only do it a few times,
        // a well designed HashCode will have each bucket be as small as possible.
        for(int i = 0; i < students.Length; i++)
        {
            if(students[i].Equals(student))
            {
                return students[i];
            }
        }
        return null;
    }
