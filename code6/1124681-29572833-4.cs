    class Student
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public char Grade { get; private set; }
    
        public Student(int id, string name)
        {
            ID = id;
            Name = name;
        }
    
        public void SetGrade(float score)
        {
            if (score>=90.0f)
                Grade='A';
            else if (score>=80.0f)
                Grade ='B';
            else if (score>=70.0f)
                Grade ='C';
            else if (score>=60.0f)
                Grade ='D';
            else
                Grade ='F';
        }
    }
