    protected void ASPxCallbackPanel2_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
    {
       ASPxCallbackPanel panel = sender as ASPxCallbackPanel;
       panel.JSProperies.Clear();
       // JSProperties have to begin with a 'cp'
       panel.JSProperties.Add("cpIsOk", true);
    }
