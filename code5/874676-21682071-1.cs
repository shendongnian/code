        using System;
        using System.Collections.Generic;
        using System.Linq;
        using SVSVoidSurveyDesigner.Database;
       namespace SVSVoidSurveyDesigner.DataAccessLayer
       {
       public class Levels
       {
        public static IEnumerable<Level> GetLevels(int intSurveyId)
        {
            var dataContext = new SVSCentralDataContext();
            
            var levels = (from l in dataContext.SVSSurvey_Levels where l.SurveyID == intSurveyId
                                 select new Level
                                 {
                                     Id = l.ID,
                                     SurveyId = l.SurveyID,
                                     UserCode = l.UserCode ,
                                     ExternalRef = l.ExternalRef ,
                                     Description = l.Description ,
                                     ParentLevelId = (l.ParentLevelID),
                                     LevelSequence = ( l.LevelSequence ),
                                    
                                     Active = Convert .ToBoolean( l.Active )
                                 });
            return levels;
        }
    }
