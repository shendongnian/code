    public void DoFillDG()
    {
     var myList = (from m in #db.MyClass#
                  select m).ToList();
     DG.DataSource = myList;
    }
