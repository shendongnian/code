    // Put the using statements at the beginning of the code module
    using System.Threading;
    using System.Globalization;
    // Put the following code before InitializeComponent()
    // Sets the culture to French (France)
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
    // Sets the UI culture to French (France)
    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
