    Task.Factory.StartNew(() => {
        // ... run this block in a background thread
        ListItemCollection GFGZListe = selektierteListe.GetItems(query);
        clientctx.Load(GFGZListe);
        // return the result to the continuation block (below)
        return GFGZListe;
    }).ContinueWith(task => {
        // handle results
        foreach (ListItem item in task.Result)
        {
            ListBox2010.Items.Add("" +item["FileleafRef"]);
        }
    }, 
    TaskScheduler.FromCurrentSynchronizationContext());    // use the UI thread for the continuation
