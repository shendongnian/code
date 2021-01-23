        static readonly String tableName;
        static ScriptMain()
        {
            // An object reference is required for the non-static field, method, or property 'Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase.Dts.get'
            tableName = Dts.Variables["ssisString"].Value.ToString();
        }
		public void Main()
		{
            // this works
            string local = Dts.Variables["ssisString"].Value.ToString();
            // a static read only field cannot be assinged to (except in a static constructor or a variable initializer)
            tableName = Dts.Variables["ssisString"].Value.ToString();
            Dts.TaskResult = (int)ScriptResults.Success;
        }
