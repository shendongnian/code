    public void  ClearLists()
    {
        Gendercmb.DataSource = Enum.GetValues(typeof(GenderType));
        Categorylst.DataSource = Enum.GetValues(typeof(Categorytype));
        Resultlst.DataSource = new List<ListItem>();
        foodItemslst.DataSource = new List<ListItem>();
    }
