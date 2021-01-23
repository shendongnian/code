    public static void BuildPaging(Control pagingControl, 
                short currentPage, short totalPages,  Action<type> action)
      for (int i = 0; i < totalPages; i++)
    {
        LinkButton pageLink = new LinkButton();
        ...
        pageLink.Click += action;
        pagingControl.Controls.Add(paheLink);
    }
  
