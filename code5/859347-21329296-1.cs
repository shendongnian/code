    public class SqlEditorTabbedEditorPane
    {
        private readonly FieldInfo m_displaySqlResultsControl;
        public SqlEditorTabbedEditorPane(Assembly sqlEditor)
        {
            Type sqlEditorTabbedEditorPane =
                sqlEditor.GetType(
                    "Microsoft.VisualStudio.Data.Tools.SqlEditor.UI.TabbedEditor.SqlEditorTabbedEditorPane");
            m_displaySqlResultsControl = sqlEditorTabbedEditorPane.GetField(
                "_resultsControl",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }
        public FieldInfo DisplaySqlResultsControl
        {
            get
            {
                return this.m_displaySqlResultsControl;
            }
        }
    }
    public class DisplaySqlResultsTabControl2012
    {
        private readonly object m_displaySqlResultsTabControl;
        private readonly QueryExecutor m_queryExecutor;
        public DisplaySqlResultsTabControl2012(
            object scriptEditor,
            SqlEditorTabbedEditorPane sqlScriptEditorControl)
        {
            m_displaySqlResultsTabControl = sqlScriptEditorControl.DisplaySqlResultsControl.GetValue(scriptEditor);
            m_queryExecutor = new QueryExecutor(m_displaySqlResultsTabControl);            
        }
        public DisplaySqlResultsTabControl2012(object scriptEditor, SqlEditorTabbedEditorPane sqlScriptEditorControl)
        {
            m_displaySqlResultsTabControl = sqlScriptEditorControl.DisplaySqlResultsControl.GetValue(scriptEditor);
            m_queryExecutor = new QueryExecutor(m_displaySqlResultsTabControl);
        }
        public object DisplaySqlResultsTabCtr
        {
            get
            {
                return m_displaySqlResultsTabControl;
            }
        }
        public QueryExecutor QueryExecutorWrapper
        {
            get
            {
                return m_queryExecutor;
            }
        }
        public class QueryExecutor
        {
            private readonly object m_queryExecutor;
            public QueryExecutor(object displaySqlResultsTabControl)
            {
                FieldInfo queryExecutor = displaySqlResultsTabControl.GetType()
                    .GetField("_queryExecutor", BindingFlags.Instance | BindingFlags.NonPublic);
                if(queryExecutor != null)
                {
                    this.m_queryExecutor = queryExecutor.GetValue(displaySqlResultsTabControl);
                }
            }
            public object QueryExec
            {
                get
                {
                    return m_queryExecutor;
                }
            }
        }        
    }
