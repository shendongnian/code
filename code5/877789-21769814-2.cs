    public Boolean CheckAssessment(String assessmentName)
    {
      {
        SQL_TA_SCOREBOARDEntities1 d = new SQL_TA_SCOREBOARDEntities1();
        Assessment A_List = new Assessment();
        {
            var qry2 = (from b in contxt.View_Assessment
                       where b.AssessmentName == assessmentName
                       select b.AssessmentName).FirstOrDefault();
            if (qry2 = assessmentName.ToString())
            {
                return true;                         
            }
            else
            {
                return false;
            }
        }
      }
    }
