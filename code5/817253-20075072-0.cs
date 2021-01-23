    public class SortByYears : IComparer
    {
        int IComparer.Compare(Object x, Object y)
        {
            if(x is Cars)
            {
                Cars X = (Cars)x
                if(y is Cars)
                {
                    Y = (OtherCars)y;                
                    return (X.Year.CompareTo(Y.Year));
                if(y is OtherCars)
                {
                    Y = (OtherCars)y;                
                    return (X.Year.CompareTo(Y.Year));
                }
            }
            if(x is OtherCars)
            {
                 ... repeat upper block
            }
        }
    }
