    context.CourseEnrolments.Local.CollectionChanged += (sender, e) =>
    {
        Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>{
            Debug.Assert(e.NewItems.OfType<CourseEnrolment>().All(x => x.Adviser != null), "newly added entity has null navigation properties");
         }));
    };
