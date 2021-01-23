        namespace SVSVoidSurveyDesigner.DataAccessLayer
        {
            public class Level
            {
            public int Id { get; set; }
            public int SurveyId { get; set; }
            public string UserCode { get; set; }
            public string ExternalRef { get; set; }
            public string Description { get; set; }
            public int? ParentLevelId { get; set; }
            public int? LevelSequence { get; set; }
            public bool Active { get; set; }
            }
        }
