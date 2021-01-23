    public Student this [int i]
    {
        get 
        {
            return students[i];
        }
        set
        {
            if (i < students.Count) {
                students[i] = value;
                Changed(this);
            } else if (i == students.Count) {
                students.Add(value);
                Changed(this);
            } else {
                throw new IndexOutOfRangeException(
                    "Student at this index is not accessible.");
            }
        }
    }
