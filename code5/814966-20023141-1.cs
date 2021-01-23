    return Observable.Create<DbObject>(obs =>
    {
        Observable.Start(() => {
            var cursor = Database.Instance.GetAllObjects();
            var status = cursor.MoveToFirst();
            while (status == DbStatus.OK)
            {
                var dbObject= Db.Create(cursor);
                obs.OnNext(dbObject);
                status = cursor.MoveToNext();
            }
            obs.OnCompleted();
        }, RxApp.TaskPoolScheduler);
        return Disposable.Empty;
    });
