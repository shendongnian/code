    public class Type
    {
        public string currency { get; set; }
        public int OrderNo { get; set; }
    }
    public class BaseClass
    {
        // w.r.t ref, do you mean to reassign objList to the filtered lists?
        public void SplitList(ref IList<Type> objList)
        {
            var SplitA = objList.Where(c => c.currency == "USD").ToList();
            var SplitB = objList.Where(c => c.currency == "GBR").ToList();
            if (SplitA.Count() > 0)
            {
                Update(SplitA);
            }
            if (SplitB.Count() > 0)
            {
                Update(SplitB);
            }
        }
        public virtual IList<Type> Update(IList<Type> updateList)
        {
            int count = 0; 
            foreach (Type objType in updateList)
            {
                objType.OrderNo = count++;
            } 
            return updateList;
        }
    }
