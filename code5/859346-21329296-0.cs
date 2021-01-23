    private static void SetConnectionForQueryWindow(Window queryWindow, 
    UIConnectionInfo uiConnectionInfo, SqlConnection conn)
        {
            object tempQueryWindow;
            Dictionary<string, object> openedQueryWindows;
            List<Window> temp = new List<Window> { queryWindow };
            openedQueryWindows = GetAllOpenedQueryWindows2012(temp);
            openedQueryWindows.TryGetValue(queryWindow.Document.FullName, out tempQueryWindow);
            if(tempQueryWindow == null)
            {
                return;
            }
            Assembly sqlEditor = Assembly.LoadFrom(tempQueryWindow.GetType().Assembly.Location);
            var sqlScriptEditorControl = new SqlEditorTabbedEditorPane(sqlEditor);
            var displaySqlResultsTabControl = new DisplaySqlResultsTabControl2012(tempQueryWindow, sqlScriptEditorControl);
            try
            {
                var connectionStrategyField =
                    displaySqlResultsTabControl.QueryExecutorWrapper.QueryExec.GetType()
                        .GetField("_connectionStrategy", BindingFlags.Instance | BindingFlags.NonPublic);
                var connectionStrategy = connectionStrategyField.GetValue(displaySqlResultsTabControl.QueryExecutorWrapper.QueryExec);
                var connection = connectionStrategy.GetType()
                    .GetField("_connectionInfo", BindingFlags.Instance | BindingFlags.NonPublic);
                connection.SetValue(connectionStrategy, uiConnectionInfo);
                var setDbConn = connectionStrategy.GetType()
                    .GetMethod("SetDbConnection", BindingFlags.NonPublic | BindingFlags.Instance);
                object[] parametersArray = { conn };
                setDbConn.Invoke(connectionStrategy, parametersArray);
            }
            catch(NullReferenceException nullReferenceException)
            {
                
            }
        }
    internal static Dictionary<string, object> GetAllOpenedQueryWindows2012(List<Window> windows)
        {
            Dictionary<string, object> openedQuerySqlWindows = new Dictionary<string, object>();
            foreach(Window window in windows)
            {
                foreach(Window queryWindow in window.Document.ActiveWindow.Collection)
                {
                    if(queryWindow.Object == null)
                    {
                        continue;
                    }
                    if(queryWindow.Object.ToString()
                       != "Microsoft.VisualStudio.Data.Tools.SqlEditor.UI.TabbedEditor.SqlEditorTabbedEditorPane")
                    {
                        continue;
                    }
                    object sqlEditorTabbedEditorPane = queryWindow.Object;
                    if(!openedQuerySqlWindows.ContainsKey(queryWindow.Document.FullName))
                    {
                        openedQuerySqlWindows.Add(queryWindow.Document.FullName, sqlEditorTabbedEditorPane);
                    }
                }
            }
            return openedQuerySqlWindows;
        }
