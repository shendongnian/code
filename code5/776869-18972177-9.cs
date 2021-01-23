    public class MyFirstView : YourBaseView
    {
        [Import] /* using MEF, but you can also do MvvmLight or whatever */
        public MyFirstViewModel ViewModel { /* based on datacontext */ }
    }
