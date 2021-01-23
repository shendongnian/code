    public Boolean IsUnique(Int32 activityID, Int32 taskID)
    {
        Int32 existsInThreeHints = ThreeHintsRepository.
            Any(hint =>
                    hint.activityID == activityID &&
                    hint.taskID == taskID) ? 1 : 0;
    
        Int32 existsInQuestions = QuestionsRepository.
            Any(question =>
                    question.activityID == activityID &&
                    question.taskID == taskID) ? 1 : 0;
    
        Int32 existsInQuestionHint = QuestionHintRepository.
            Any(questionHint =>
                    questionHint.activityID == activityID &&
                    questionHint.taskID == taskID) ? 1 : 0;
    
        return existsInThreeHints + existsInQuestions + existsInQuestionHint <= 1;
    }
