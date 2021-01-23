        Incident inc = new Incident
        {
            StartDateTime = DateTime.Now
        };
        Model.db.Incidents.InsertOnSubmit(inc);
        inc.Name = "Incident #" + inc.ID;
        try
        {
            Model.db.SubmitChanges();
            inc.Name = "Incident #" + inc.ID;
            Model.db.SubmitChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Model.db.SubmitChanges();
        }
