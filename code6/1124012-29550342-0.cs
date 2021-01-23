    class MyEqualityComparer : IEqualityComparer<object>
    {
        #region IEqualityComparer<object> Members
        bool IEqualityComparer<object>.Equals(object x, object y)
        {
            return (x as dynamic).Id == (y as dynamic).Id;
        }
        int IEqualityComparer<object>.GetHashCode(object obj)
        {
            return ((obj as dynamic).Id as object).GetHashCode();
        }
        #endregion
    }
