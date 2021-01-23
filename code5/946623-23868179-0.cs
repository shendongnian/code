    <script runat="server">
    protected void Application_BeginRequest()
    {
        System.Globalization.CultureInfo cInf = new System.Globalization.CultureInfo("de-CH", false);
        cInf.NumberFormat.CurrencySymbol = "CHF";
        System.Threading.Thread.CurrentThread.CurrentCulture = cInf;
        System.Threading.Thread.CurrentThread.CurrentUICulture = cInf;
    }
    </script>
