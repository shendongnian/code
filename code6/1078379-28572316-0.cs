    class PackageStatusSSISUI : Microsoft.SqlServer.Dts.Runtime.Design.IDtsTaskUI
    {
        private TaskHost _taskHost;
        private IServiceProvider _serviceProvider;
        public System.Windows.Forms.ContainerControl GetView()
        {
            PackageStatusForm editor = new PackageStatusForm(this._taskHost, this._serviceProvider);
            return editor;
        }
        public void Initialize(TaskHost taskHost, IServiceProvider serviceProvider)
        {
            this._taskHost = taskHost;
            this._serviceProvider = serviceProvider;
        }
    }
