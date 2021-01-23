    var temp
            = dbconnect.tblAnswerLists
                       .Where(i => i.StudentNum == studentNumber && i.username==objstu.Return_SupervisorUserName_By_StudentNumber(studentNumber))
                       .ToList() // <-- This will bring the data into memory.
                       .Select(i => new PresentClass.supervisorAnswerQuesttionPres
                           {
                               answerList = Return_Answer_List(studentNumber,i.dateOfAnswer.Value.Date),
                               questionList = Return_Question_List(studentNumber, i.dateOfAnswer.Value.Date),
                               date = ConvertToPersianToShow(i.dateOfAnswer.Value.Date)
                           })
                       .GroupBy(i => i.date)
                       .OrderByDescending(i => i.Key)
                       .ToList();
