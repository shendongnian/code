    using Knockout;
    
    namespace ViewModels
    {
        public class FooViewModel
        {
                private readonly Observable<string> bar;        
                private readonly Observable<string> computed;        
    
            public FooViewModel()
            {
                bar = Global.Observable("HelloWorld"); //Translates to ko.observable("HelloWorld") on client
                computed = Global.Computed(() => bar.Get() + "COMPUTED");
            }
    
            public Observable<string> Bar { get { return bar; } }
            public Observable<string> Computed { get { return computed; } }
        }
    }
