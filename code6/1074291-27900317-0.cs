    public static void BuildPaging(Control pagingControl
                                  , short currentPage
                                  , short totalPages
                                  , EventHandler eh // <- this one
                                  )
    {
        for (int i = 0; i < totalPages; i++)
        {
            LinkButton pageLink = new LinkButton();
            ...
            pageLink.Click += eh;
            pagingControl.Controls.Add(paheLink);
        }
    }
