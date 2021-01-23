    Task.Factory.StartNew(() => 
    {
        myObject1.myFunction(10, "Test");
        myObject2.myFunction(20, "Test");
        myObject3.myFunction(30, "Test"); 
    }).ContinueWith(task => {
            if(task.IsFaulted)
            {
                AggregateException ex = task.Exception;
                //handle exception
            }
        });
