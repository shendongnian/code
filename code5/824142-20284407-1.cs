    public interface ICalcEntity
    {
        void Delete(ICalcRepo repo);
    }
    public interface ICalcRepo
    {
        void Delete(CALC_Master cMaster);
        void Delete(CALC_plan cPlan);
    }
    public class CalcRepo : ICalcRepo
    {
        public void Delete(CALC_Master cMaster)
        {
            //delete CALC_Master where CALC_Id == cMaster.CALC_Id
        }
        public void Delete(CALC_plan cPlan)
        {
            //delete
        }
    }
    public class CALC_plan : ICalcEntity
    {
        public void Delete(ICalcRepo repo)
        {
            repo.Delete(this);
        }
    }
    public class CALC_Master : ICalcEntity
    {
        public int CALC_Id { get; set; }
        public List<ICalcEntity> Children { get; set; }
        public void Delete(ICalcRepo repo)
        {
            Children.ForEach(c => c.Delete(repo));
            repo.Delete(this);
        }
    }    
