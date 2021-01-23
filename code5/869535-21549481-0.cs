    public class RecStatusDA : BaseDA
    {
        public List<tblRecStatus> GetAll()
        {
           return (from tblRecStatus s in this.DataContext.tblRecStatus
                        select s).ToList();
        }
    }
