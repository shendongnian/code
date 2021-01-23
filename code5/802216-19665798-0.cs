    private List<int> selectedCategories;
    public List<int> SelectedCategories
    {
        get
        {
            if (selectCategories == null)
            {
                selectedCategories = Categories.Select(m => m.Id).ToList();
            }
            return selectedCategories;
        }
        set { selectedCategories = value; }
    }
