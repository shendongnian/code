    public interface IFoo
    {
    }
    public interface IBar
    {
    }
    public class DualList : IList<IFoo>, IList<IBar>
    {
        List<IFoo> list1 = new List<IFoo>();
        List<IBar> list2 = new List<IBar>();
        #region IList<IFoo> Members
        int IList<IFoo>.IndexOf(IFoo item)
        {
            return list1.IndexOf(item);
        }
   
        // Etc etc
        #endregion
        #region IList<IBar> Members
        int IList<IBar>.IndexOf(IBar item)
        {
            return list2.IndexOf(item);
        }
        // Etc etc
        #endregion
    }
