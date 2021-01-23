    private async Task outputFiles(IEnumerable<object> paths) 
    { 
        foreach (var o in paths) 
        {
             await Task.Delay(1); // Delay so the UI can update the List
            _fileCollection.Add(o); 
        }
        this.observer = Observable.Buffer(dir.EnumerateFiles(myfile,System.IO.SearchOption.AllDirectories, true).ToObservable(Scheduler.Default), TimeSpan.FromSeconds(.5), Scheduler.Default) 
    } 
    this.observer = Observable.Buffer(dir.EnumerateFiles(myfile, System.IO.SearchOption.AllDirectories, true).ToObservable(Scheduler.Default), TimeSpan.FromSeconds(.5), Scheduler.Default).ObserveOn(syncContext).Subscribe(async x => await outputFiles(x));
