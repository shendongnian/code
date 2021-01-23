    public void doAsync(){
       var list = new List<ofSomething>();
       Task.Factory.StartNew(()=>{
            //You are now in a new thread, just do your stuff here.
            var somerange = GetSomeRange();
            list.AddRange(somerange);
       }).Continue((p)=>{
           //you are now on GUI thread send event or return the list.
           //I personally like to send events.
           if(PostDataReady != null) PostDataReady(list);
       });
    }
