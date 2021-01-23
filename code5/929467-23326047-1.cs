    //Create the object
    QuestionUnit question = new QuestionUnit(...);
    //Read properties
    question.Question = line;
    question.Answer = thereader.ReadLine();
    question.CorrentAnswer = thereader.ReadLine();
    question.Explanation = thereader.ReadLine();
    //Set the object to an element in the array
    m_Questions[counter] = question;
