    for (i = PagSize; i <= dt.Rows.Count; i++)
      {
         Curr = dt.Rows[i - 1]["Brand"].ToString();
            if (i < dt.Rows.Count)
             {
               Nxt = dt.Rows[i]["Brand"].ToString();
               diff = dt.Rows.Count - i;
               if (Curr != Nxt)
               {
                DctPaging.Add(PageNum, i);
                PageNum = PageNum + 1;
                i = i + PagSize;
                if (i >= dt.Rows.Count)
                {
                 DctPaging.Add(PageNum, dt.Rows.Count);
                 break;
                }
            }
       }
