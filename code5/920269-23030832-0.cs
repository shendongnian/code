    public class CategoryComparer : IComparer<Category>
    {
        List<int> orderNums =
            new List<int> { 3, 17, 13, 176, 4, 177, 179, 178, 180, 181, 182, 183, 184, 185, 186, 139 };
    
        public int Compare(Category x, Category y)
        {
            var index1 = orderNums.IndexOf(x.id);
            var index2 = orderNums.IndexOf(y.id);
    
            if (index1 == index2)
                return 0;
    
            return index1 > index2 ? 1 : -1;
        }
    }
