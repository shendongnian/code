    dynamic apiObject = webBrowser.Document.InvokeScript("apiObject");
    string property = apiObject.property;
    MessageBox.Show(property);
    apiObject.Method1("Hello!");
    MessageBox.Show(apiObject.Method2());
