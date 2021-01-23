    [System.AddIn.AddIn("ScriptMain", Version = "1.0", Publisher = "", Description = "")]
    public partial class ScriptMain : Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase
    { 
        #region VSTA generated code
        enum ScriptResults
        {
            Success = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
            Failure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure
        };
        #endregion
        /*
	         Info regarding Script Task usage.
	    */
        public void Main()
        {
            int connectionCount = GetConnectionCount();
            DTSReadOnlyCollectionBase arCon = Dts.Connections;
            NewClass n = new NewClass(arCon);
            connectionCount = n.GetConnectionCount2();
            Dts.TaskResult = (int)ScriptResults.Success;
        }
        public int GetConnectionCount()
        {
            return Dts.Connections.Count;
        }
    }
    public class NewClass : Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase
    {
        DTSReadOnlyCollectionBase dtsConnections;
        public NewClass(DTSReadOnlyCollectionBase dtsCon)
        {
            dtsConnections = dtsCon;
        }
        public int GetConnectionCount2()
        {
            return dtsConnections.Count;
        }
    }
}
