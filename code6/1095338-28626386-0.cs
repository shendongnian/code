    combinedTask.ContinueWith(_=>{
        if (_.IsFaulted){
            if (typeof(_.Exception) == typeof(TaskCancelledException){
                // Do Nothing
            }
        }
    })
