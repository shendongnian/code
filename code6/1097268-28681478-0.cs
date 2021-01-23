    public List<string> HeatGet(int heatNumbers, List<string> list)
        {
            List<string> heatStringList = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                heatStringList.Add("T" + Math.Ceiling((i + 1) *  (float)heatNumbers / list.Count));
            }
            return heatStringList;
        }
