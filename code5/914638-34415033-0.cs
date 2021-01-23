    public class NullStringCriterion : StringCriterion
    {
        public override string GetQuery(string propertyName)
        {
            return String.Format(" ({0} IS NULL) ", propertyName);
        }
    }
