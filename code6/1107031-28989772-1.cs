    public void doAsync(){
       var list = new List<ofSomething>();
       Task.Factory.StartNew(()=>{
            //This are is in a new thread, just do you stuff here.
            var somerange = GetSomeRange();
            list.AddRange(somerange);
       }).Continue((p)=>{
           //you are now on GUI thread send event
           if(PostDataReady != null) PostDataReady(list);
       });
    }
