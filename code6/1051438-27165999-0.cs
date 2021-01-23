    public abstract class A
    {
        public abstract void RefreshDisplay<TView>(Views<TView> value);
    }
    
    public abstract class Views<TView>
    {
        internal Views() {} //Used to disallow inheriting from outside, not mandatory...
        //You can add other methods/properties to allow processing in RefreshDisplay method
    }
    
    public sealed class RxViews : Views<TView>
    {
        private RxViews() {}
 
        private static readonly RxViews myFirstRxView = new RxViews();
        public static RxViews MyFirstRxView { get { return myFirstRxView; } }
    }
