    public ObservableCollection<DbObject> DbObjects { get; set; }
    private async void OnLoad(object sender, RoutedEventArgs e)
    {
        // (2) UI Thread enters OnLoad
        var observableData = CatalogService.Instance.DataSource.Publish();
        var chunked = observableData
            // (6) Thread A OnNext passes into Buffer
            .Buffer(TimeSpan.FromMilliseconds(100));
            // (7) Thread B, threadpool thread used by Buffer to run timer 
        var dispatcherObs = chunked
            // (8) Thread B still
            .ObserveOnDispatcher(DispatcherPriority.Background);
            // (9) Non blocking OnNexts back to UI Thread
        dispatcherObs.Subscribe(dbObjects =>
        {
            // (10) UI Thread receives buffered dbObjects            
            foreach (var dbObject in dbObjects)
            {
                // (11) UI Thread hurting while all these images are
                // stuffed in the collection in one go - This is the issue I bet.
                DbObjects.Add(dbObject);
            }
        });
        
        await Task.Run(() =>
        {
            // (3) Thread A - a threadpool thread,
            // triggers subscription to DataSource
            // UI Thread is *NOT BLOCKED* due to await
            observableData.Connect()
        });
        // (13) UI Thread - Dispatcher call back here at end of Create call
        // BUT UI THREAD WAS NOT BLOCKED!!!
        // (14) UI Thread - This task will be already completed
        // It is causing a second subscription to the already completed published observable
        await dispatcherObs.ToTask();
    }
    public class CatalogService
    {
       ...
    
       public IObservable<DbObject> DataSource
       {
            get
            {
                return Observable.Create<DbObject>(obs =>
                {
                    // (4) Thread A runs Database query synchronously
                    var cursor = Database.Instance.GetAllObjects();
                    var status = cursor.MoveToFirst();
    
                    while (status == DbStatus.OK)
                    {
                        var dbObject= Db.Create(cursor);
                        // (5) Thread A call OnNext
                        obs.OnNext(dbObject);
    
                        status = cursor.MoveToNext();
                    }
                    
                    obs.OnCompleted();
                    // (12) Thread A finally completes subscription due to Connect()
                    return Disposable.Empty;
                });
            }
        }
    }
