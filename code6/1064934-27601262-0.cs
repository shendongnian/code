    else if (added.GetType() == typeof(TabTessereVeicoli))
    {
        TabTessereVeicoli i = (TabTessereVeicoli)added;
        i.DATA_INS = now;
        i.USER_INS = mdlImpostazioni.p.UserName;
        var listaterV = new List<TabAssVeicoliTerminali>();
        foreach (var ter in MainWindow.dbContext.TabTerminali) 
        {
            var tt = new TabAssVeicoliTerminali();
                        
            tt.MODIFICATO = true;
            tt.ABILITATO = true;
            tt.IDTER = ter.ID;
            tt.IDTEV = i.ID;
            tt.DATA_INS = now;
            tt.USER_INS = mdlImpostazioni.p.UserName;
            //listaterV.Add(tt);
            i.TabAssVeicoliTerminali.Add(tt);
        }
        //MainWindow.dbContext.BulkInsert(listaterV);
    }
