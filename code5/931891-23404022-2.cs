    [NonAction]
    private List<Model>getName()
    {
        var names = (from m in db.Models
                    select m).ToList();
        return names;
    }
    [NonAction]
    public List<Model> getAllInstituteNameList()
    {
        return getNames();
    }
