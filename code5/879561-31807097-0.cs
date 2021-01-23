    public string GetAssessmentNo(int AssessmentNo)
    {
        string AssNo = (from a in contxt.View_Assessment
                     where a.id == AssessmentNo
                     select a).Single().AssessmentName;
        return AssNo;
    }
    If you write int Assno you cannot select AssessmentName because it is string datatype.you can change method datatype int to string after this you will get AssessmentName 
    Hope it will help you
