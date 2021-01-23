    public async Task GetActivityStudentCollection()
    {
        var studentActivityColl =  await ViewModelLocator.ActivityViewModel.GetActivity(0, 8, 0, 20);
        foreach(var studentAct in studentActivityColl)
            StudentActivityCollection.Add(studentAct);
        StudentActivityCollection.CollectionChanged += StudentActivityCollection_CollectionChanged;
    //     RaisePropertyChanged("StudentActivityCollection");
    }
