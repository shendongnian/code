    public enum Gender
    {
        Man = 1,
        Woman = 2
    }
    
    public interface IGenderStrategy
    {
        string DisplayName(Gender gender);
    }
    public class ParentStrategy : IGenderStrategy
    {
        public string DisplayName(Gender gender)
        {
            string retVal = String.Empty;
            switch (gender)
            {
                case Gender.Man:
                    retVal =  "Dad";
                    break;
                case Gender.Woman:
                    retVal =  "Mom";
                    break;
                default:
                    throw new Exception("Gender not found");
            }
            return retVal;
        }
    }
    public static class EnumExtentions
    {
        public static string ToValue(this Gender e, IGenderStrategy genderStategy)
        {
            return genderStategy.DisplayName(e);
        }
    }
    public class Test
    {
        public Test()
        {
            Gender.Man.ToValue(new ParentStrategy());
        }
    }
