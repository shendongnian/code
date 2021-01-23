     private string TestScores(decimal Test)
        {
            string testGrade = null;
    
            //Perform the function
            if (Test >= 90) {
                testGrade = "A";
            } else if (Test >= 80) {
                testGrade = "B";
            } else if (Test >= 70) {
                testGrade = "C";
            } else if (Test >= 60) {
                testGrade = "D";
            } else if (Test < 60) {
                testGrade = "F";
            }
            //return the answer
            return testGrade;
        }
