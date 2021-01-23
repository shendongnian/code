    class CompareLines : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string[] bSplitX = x.Split('\t');
            string[] bSplitY = y.Split('\t');
    
            DateTime bTempDateX = DateTime.ParseExact(bSplitX[4], "MMddyyyy", null);
            DateTime bTempDateY = DateTime.ParseExact(bSplitY[4], "MMddyyyy", null);
    
            if (DateTime.Compare(bTempDateX, bTempDateY) > 0)
                return 1;
            else if (DateTime.Compare(bTempDateX, bTempDateY) < 0)
                return -1;
            else
                return String.Compare(bSplitX[3], bSplitY[3]);
        }
    }
