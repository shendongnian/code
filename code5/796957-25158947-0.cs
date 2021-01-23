    Entities dbconn = new Entities();
    List<keyData> temRes = (
        from viewData in dbconn.vw1.ToList()
        join hData in dbconn.tableH.ToList()
        on new { pid= (int)viewData.pid, proid= viewData.proid}
        equals new { pid= (int)hData .pid, proid= hData .proid}
        into joinSet
        from joinUnit in joinSet.DefaultIfEmpty()
        where joinUnit == null
        select new { pid= (int)viewData.pid, sid= (int)viewData.sid, proid= viewData.proid,  Title=viewData.Title }
        ).ToList();
