    public static IList<Sending> ReflectData(DataTable sendingList, DataTable statusList)
    {
        List<Sending> list = Activator.CreateInstance<List<Sending>>();
        var property = typeof(Sending).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
        foreach (DataRow dr in sendingList.Rows)
        {
            Sending sendingInstance = Activator.CreateInstance<Sending>();
            foreach (var p in property)
            {
                try
                {
                    p.SetValue(sendingInstance, dr[p.Name], null);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            DataRow[] row = statusList.Select("SendingID = " + dr[0]);
            foreach (DataRow r in row)
            {
                StatusHistory statusInstance = Activator.CreateInstance<StatusHistory>();
                var porpsh = statusInstance.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
                foreach (var psh in porpsh)
                {
                    try
                    {
                        psh.SetValue(statusInstance, r[psh.Name], null);
                    }
                    catch { }
                }
                sendingInstance.StatusHistory.Add(statusInstance);
            }
            list.Add(sendingInstance);
        }
        return list;
    }
