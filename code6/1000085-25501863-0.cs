    private void SaveItemDetails()
    {
    
    using(context dc = new context())
    {
        foreach(var itemLine in ObsItemLineDetails )
            {
                var today = DateTime.Today.AddSeconds(-1);
                var newCommentDate = (Int32)(today.Subtract(new DateTime(1970, 1, 1,0,0,0))).TotalSeconds;
    
                var itemDetail = dc.ItemLineDetails.Where(d => d.ItemCode.Equals(itemLine.ItemCode) && 
                    d.LineId == itemLine.LineId && 
                    d.SearchDate == itemLine.SearchDate).FirstOrDefault();
                if (itemDetail != null)
                {
                    itemDetail.CommentDate = newCommentDate;
                    itemDetail.Comments = GetAutoComment();
                    dc.UpdateObject(itemDetail);                    
                }
            }                     
            dc.SaveChanges(); 
    }
    }
