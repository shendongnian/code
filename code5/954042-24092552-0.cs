    webBrowser.Url = new Uri("http://files.jga.so/stackoverflow/input.html");
    webBrowser.DocumentCompleted += (sender, eventArgs) =>
    {
         var eleNormal = (IHTMLInputElement)webBrowser.Document.GetElementById("normal").DomElement;
         var eleReadOnly = (IHTMLInputElement)webBrowser.Document.GetElementById("readonly").DomElement;
         var eleDisabled = (IHTMLInputElement)webBrowser.Document.GetElementById("disabled").DomElement;
         MessageBox.Show(eleNormal.value);
         MessageBox.Show(eleReadOnly.value);
         MessageBox.Show(eleDisabled.value);
    };
