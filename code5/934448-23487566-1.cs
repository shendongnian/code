    private void btnCopy_Click(object sender, EventArgs e)
        {
            List<detail> detail = new List<detail>();
            List<detail> CopyDetail = new List<detail>();
            detail.Add(new detail{item1=1,item2=1});
            foreach (detail item in detail)
            {
                CopyDetail.Add(new detail{item1=item.item1,item2=item.item2});
            }
     
        }
         
    
    public class detail
    
    {
        public int item1;
        public int item2;
    }
