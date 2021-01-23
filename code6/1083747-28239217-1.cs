    public class UserDataPropertyDescriptorCollection : PropertyDescriptorCollection
    {
        public override PropertyDescriptorCollection Sort(IComparer comparer)
        {
            UserDataComparer customComparer = new UserDataComparer();
            return base.Sort(customComparer);
        }
    }
    public class UserDataComparer : IComparer
    {
        #region IComparer Members
        int IComparer.Compare(object x, object y)
        {
            //cast and compare UserDataCollectionPropertyDescriptor index values
        }
        #endregion
    }
