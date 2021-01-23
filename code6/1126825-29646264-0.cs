    public void RemoveStudentWithNumber(int number)
    {
        for (int i = 0; i < students.Length; i++)
        {
            if (students[i].Number == number)
            {
                // move all subsequent students one down,
                // closing the gap.
                if( i != students.Length-1) 
                {
                    Array.Copy(students, i+1, students, i, students.Length-i-1);
                }
                // Now resize. 
                Array.Resize(ref students, students.Length-1);
            }
        }
    }
