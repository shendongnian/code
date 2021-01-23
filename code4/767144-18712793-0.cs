    public string Grade(int examScore)
    {
        string grade = "D";
        if(examScore>=90)
        {
            grade="A";
            return grade;
        }
        if(examScore>=80)
        {
            grade="B";
            return grade;
        }
        if(examScore>=70)
        {
            grade="C";
            return grade;
        }
        if(examScore>=60)
        {
            grade="D";
            return ;
        }
        return grade;
    }
