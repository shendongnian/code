     public class MyQuizGroupsCollection: IEnumerable<QuizGroups>
     {
         // other stuff
         public QuizGroups this[string sectorId]
         { get  { return FirstOrDefault(x => x.Subtitle == sectorId); } }
     }
