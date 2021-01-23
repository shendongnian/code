      [NotifyPropertyChanged]
      public class OsModell //...
      {
        public OsModell()
        {
          //...
    
          #region feliratkozás helyi propertychangedre úgy, hogy még dizájn alatt nem létezik
          //forrás: http://msdn.microsoft.com/en-us/library/ms228976(v=vs.100).aspx
          {
            EventInfo feliratkozasiSegedEventInfo = this.GetType().GetEvent("PropertyChanged");
            Type propertyChangedEventhandlerTipusa = feliratkozasiSegedEventInfo.EventHandlerType;
            MethodInfo segedAhhozAmitMajdAdattartalomValtozasahozCsatolok = this.GetType().GetMethod("megvaltozottAzAdattartalom", BindingFlags.NonPublic | BindingFlags.Instance);
            Delegate d = Delegate.CreateDelegate(propertyChangedEventhandlerTipusa, this, segedAhhozAmitMajdAdattartalomValtozasahozCsatolok);
            MethodInfo addHandler = feliratkozasiSegedEventInfo.GetAddMethod();
            Object[] addHandlerArgs = { d };
            addHandler.Invoke(this, addHandlerArgs);
          }
          #endregion
        }
    
        protected void megvaltozottAzAdattartalom(Object sender, EventArgs e)
        {
          //...
        }
