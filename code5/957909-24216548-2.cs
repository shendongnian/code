    public interface IEntity
    {
        string LastUpdateUserID { get; set; }
        DateTime LastUpdateDate { get; set; }
    }
    public static class EntityExtensions
    {
        /// <summary>
        /// Extension Method for IEntity
        /// </summary>
        public static void PopulateAudit<T>(this T entity)
            where T: IEntity
        {
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdateUserID = "john.doe"; //or pull this from a service somewhere
        }
    }
