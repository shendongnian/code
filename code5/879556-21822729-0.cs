    public int GetAssessmentNo(int AssessmentNo)
    {
        int AssNo = (from a in contxt.View_Assessment
                     where a.id == AssessmentNo
                     select a).Single().AssessmentName;
        return AssNo;
    }
