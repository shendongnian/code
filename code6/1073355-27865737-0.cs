    int pageidx = gvDetails.PageIndex;
    int pagesize = gvDetails.PageSize;
    int startidx = pageidx * pagesize;
    int endidx = startidx + pagesize;
    int sum = 0;
    for (int i = startidx; i < endidx; i++)
    {
        sum += Int.Parse(gvDetails.Rows[i].Cells[4].Value.ToString());
    }
    lblTotal.Text = sum.ToString(); 
