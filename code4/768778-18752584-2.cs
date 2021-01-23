    public static int GetCsStatus()
    {
        using (Entities db = new Entities())
        {
            System.Data.Objects.ObjectParameter s = new System.Data.Objects.ObjectParameter("Status", typeof(int));
            int r = db.proc_CsStatus(120, s);
            return (int)s.Value;
        }
    }
