        public enum ActionTypeEnumeration
        {
            Navigation = 1,
            Javascript = 2,
            UIThreadDependent = 3,
            UNDEFINED = 99
        }
        public class ActionDescriptor
        {
            public Action Action { get; set; }
            public ActionTypeEnumeration ActionType { get; set; }
        }
        /// <summary>
        /// Executes a set of WebBrowser control's Automation actions
        /// </summary>
        /// <remarks>
        ///  Test form shoudl ahve the following controls:
        ///    webBrowser1 - WebBrowser,
        ///    testbutton - Button,
        ///    testCheckBox - CheckBox,
        ///    totalHtmlLengthTextBox - TextBox
        /// </remarks> 
        private async void testButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cts = new CancellationTokenSource(60000);
                var actions = new List<ActionDescriptor>()
                {
                    new ActionDescriptor() { Action = ()=>  wb.Navigate("www.yahoo.com"), ActionType = ActionTypeEnumeration.Navigation}  ,
                    new ActionDescriptor() { Action = () => wb.Navigate("www.microsoft.com"), ActionType = ActionTypeEnumeration.Navigation}  ,
                    new ActionDescriptor() { Action = () => wb.Navigate("asp.net"), ActionType = ActionTypeEnumeration.Navigation}  ,
                    new ActionDescriptor() { Action = () => wb.Document.InvokeScript("eval", new[] { "$('p').css('background-color','yellow')" }), ActionType = ActionTypeEnumeration.Javascript}, 
                    new ActionDescriptor() { Action =
                    () => {
                             testCheckBox.Checked = wb.DocumentText.Contains("Get Started"); 
                           },
                           ActionType = ActionTypeEnumeration.UIThreadDependent} 
                    //... 
                };
                foreach (var action in actions)
                {
                   string html = await ExecuteWebBrowserAutomationAction(cts.Token, action.Action, action.ActionType);
                   // count HTML web page stats - just for fun
                   int totalLength = 0;
                   Int32.TryParse(totalHtmlLengthTextBox.Text, out totalLength);
                   totalLength += !string.IsNullOrWhiteSpace(html) ? html.Length : 0;
                   totalHtmlLengthTextBox.Text = totalLength.ToString();   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");   
            }
        }
        // asynchronous WebBroswer control Automation
        async Task<string> ExecuteWebBrowserAutomationAction(
                                CancellationToken ct, 
                                Action runWebBrowserAutomationAction, 
                                ActionTypeEnumeration actionType = ActionTypeEnumeration.UNDEFINED)
        {
            var onloadTcs = new TaskCompletionSource<bool>();
            EventHandler onloadEventHandler = null;
            WebBrowserDocumentCompletedEventHandler documentCompletedHandler = delegate
            {
                // DocumentCompleted may be called several times for the same page,
                // if the page has frames
                if (onloadEventHandler != null)
                    return;
                // so, observe DOM onload event to make sure the document is fully loaded
                onloadEventHandler = (s, e) =>
                    onloadTcs.TrySetResult(true);
                this.wb.Document.Window.AttachEventHandler("onload", onloadEventHandler);
            };
            this.wb.DocumentCompleted += documentCompletedHandler;
            try
            {
                using (ct.Register(() => onloadTcs.TrySetCanceled(), useSynchronizationContext: true))
                {
                    runWebBrowserAutomationAction();
                    
                    if (actionType == ActionTypeEnumeration.Navigation)
                    {
                        // wait for DOM onload event, throw if cancelled
                        await onloadTcs.Task;
                    }
                }
            }
            finally
            {
                this.wb.DocumentCompleted -= documentCompletedHandler;
                if (onloadEventHandler != null)
                    this.wb.Document.Window.DetachEventHandler("onload", onloadEventHandler);
            }
            // the page has fully loaded by now
            // optional: let the page run its dynamic AJAX code,
            // we might add another timeout for this loop
            do { await Task.Delay(500, ct); }
            while (this.wb.IsBusy);
            // return the page's HTML content
            return this.wb.Document.GetElementsByTagName("html")[0].OuterHtml;
        }
