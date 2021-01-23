    public List<dataTable> GetData(string name)
    {
        using(TableEntities db = new TableEntities())
        {
            if(new Employees().GetType().ToString().Equals(name))
                //Do query
        }
    }
