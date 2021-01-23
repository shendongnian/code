    public enum UserType 
    {
       Physician,
       Police
    }
    
    public class CriteriaFactory
    {
       public static SearchCriteria CreateCriteriaFor(UserType userType)
       {
          switch(userType)
          {
             case UserType.Physician : return new SearchCriteria();
             case UserType.Police : return new PoliceSearchCriteria();
             default : return new SearchCriteria();
          }
       }
    }
