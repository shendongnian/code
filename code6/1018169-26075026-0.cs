    using(MyContext nctx = new MyContext())
    {
        nctx.Database.Connection.Open();
        var dictAllSelects = new Dictionary<string, SelectList>(){
            {"sl_task_id", new SelectList(nctx.Tasks.ToArray(), "id", "name")},
            {"sl_task_item_id", new SelectList(nctx.TaskItems.ToArray(), "id", "name")},
            {"sl_unit_id", new SelectList(nctx.Units.ToArray(), "id", "name")},
            {"sl_unit_type_id", new SelectList(nctx.UnitTypes.ToArray(), "id", "name")}
        };
        nctx.Database.Connection.Close();
    }
