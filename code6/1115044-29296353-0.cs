    public void evaluateScript(string command)
            {
    
                System.Diagnostics.Debug.WriteLine("evaluateScript: " + command);
                using (Gecko.AutoJSContext context = new AutoJSContext(geckoWebBrowser1.Window.JSContext))
                {
                    var result = context.EvaluateScript(command, geckoWebBrowser1.Window.DomWindow);
                }
            }
