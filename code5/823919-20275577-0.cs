        foreach(Results result in _results)
        {
            int examID = _theDisplay.userInputAsInteger("Select a result");
            _findExamIndex(examID, _exams);
             int studentID = _theDisplay.userInputAsInteger("Please select a users result");
            _findStudentIndex(studentID, _students);
             //filter on the _exams' Topic == '_topicName'
             exam[]  exams  = FindExamByTopic("youtopic",_exams)
        }
    
      private Exam[] FindExamByTopic(string topic, Exam[] _exams)
        {
             return _exams.Where(ex => ex.Topic == topic).ToArray();  
        } 
