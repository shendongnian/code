    public class BaseModel: IBaseModel
    {
        public DateTime CrDate { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public bool IsDeleted { get; set; }
    }
    public interface IBaseModel
        {
            DateTime CrDate { get; set; }
            ApplicationUser User { get; set; }
        }
