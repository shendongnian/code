    Question nextQuestion;
    Status status = QuizHelper.TryGetNextQuestion(db, theQuiz, out nextQuestion);
    if(status != Status.ok) {
        return new ResponseMessage() (Status = status);
    }
