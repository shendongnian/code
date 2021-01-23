    private void Work(){
        List<Artist> selectedArtistsList;
        //Code to fill selectedArtistsList with about 6,000 items not shown here
        CollectionViewSource selection1ViewSource = ((CollectionViewSource)(this.FindResource("selection1Source")));
        stopWatch1.Reset();
        stopWatch1.Start();
        selection1ViewSource.Source = selectedArtistsList;
        Debug.Print("After setting Source: {0}ms", stopWatch1.ElapsedMilliseconds.ToString());
        //New:
        Dispatcher.BeginInvoke(new Action(RenderingDone), System.Windows.Threading.DispatcherPriority.ContextIdle, null);
    }
    //New
    Stopwatch stopWatch1 = new Stopwatch();
    private void RenderingDone() {
        Debug.Print("After rendering is done: {0}ms", stopWatch1.ElapsedMilliseconds.ToString());
    }
