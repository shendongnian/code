    public interface IPrinter
    {
        void SetPage();
        void SendToPrint();
    } // eo interface IPrinter
    public class BasePrinter : IPrinter /* Could well be abstract */
    {
         protected virtual void SetPageImpl() { }      /* Also could be abstract */
         protected virtual void SendToPrintImpl() { }  /* ........ditto .....    */
         // IPrinter implementation
         public void SetPage()
         {
             SetPageImpl();
             // can do other stuff here.  Will always be called!
         } // eo SetPage
         public void SendToPrint()
         {
             SendToPrintImpl();
             // ditto
         }
    }  // eo class BasePrinter
    public class ChildPrinter : BasePrinter
    {
         // we only do something different when setting a page
         protected override void SetPageImpl()
         {
            // ChildPrinter-specifics
         } // eo SetPageImpl
    } // eo class ChildPrinter
