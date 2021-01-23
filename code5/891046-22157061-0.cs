    public Article()
    {
        This.DateCreated = DateTime.Now;
    }
    [Display(Name = "Date Created")]
    public DateTime DateCreated {get; private set;}
