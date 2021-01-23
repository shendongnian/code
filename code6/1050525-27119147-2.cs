	private void PopulatePager(int recordCount, int currentPage)
	{
		double dblPageCount = (double)((decimal)recordCount / decimal.Parse((1).ToString()));
		int pageCount = (int)Math.Ceiling(dblPageCount);
		List<ListItem> pages = new List<ListItem>();
		if (pageCount > 0)
		{
			pages.Add(new ListItem("First", "1", currentPage > 1));
			int pagesToShow = 4;
			int minPage = Math.Max(1, currentPage - (pagesToShow / 2));
			int maxPage = Math.Min(pageCount, minPage + pagesToShow);
			if (minPage > 1)
				pages.Add(new ListItem("...", (minPage - 1).ToString(), false));
			for (int i = minPage; i <= maxPage; i++)
				pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
			if (maxPage < pageCount)
				pages.Add(new ListItem("...", (maxPage + 1).ToString(), false));
			pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
		}
		System.Web.UI.HtmlControls.HtmlGenericControl g = new System.Web.UI.HtmlControls.HtmlGenericControl();
		rptPager.DataSource = pages;
		rptPager.DataBind();
	}
