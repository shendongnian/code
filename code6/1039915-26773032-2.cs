     public class CategoryDA
    {
        SchoolPlusDBContext dbContext = new SchoolPlusDBContext();
        public List<CategoryMaster> GetAllCategory()
        {
            return dbContext.CategoryMaster.OrderByDescending(t => t.CategoryID).ToList();
        }
        public bool AddCategory(CategoryMaster master,string UserName)
        {
            try
            {
                master.CreatedBy = UserName;
                master.CreatedOn = System.DateTime.Now;
                dbContext.CategoryMaster.Add(master);
                dbContext.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        
    }
}
