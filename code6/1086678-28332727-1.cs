     <Ribbon>
        <Ribbon.ApplicationMenu>
            <RibbonApplicationMenu Label="test">
                <RibbonApplicationMenuItem Header="Test" />
                <RibbonApplicationMenu.AuxiliaryPaneContent>
                    <RibbonGallery CanUserFilter="False" ScrollViewer.VerticalScrollBarVisibility="Auto" ItemsSource="{Binding JumpListMyApp}">                        
                    </RibbonGallery>
                </RibbonApplicationMenu.AuxiliaryPaneContent>
            </RibbonApplicationMenu>
        </Ribbon.ApplicationMenu>
    </Ribbon>
    class ViewModel
    {
        private ObservableCollection<string> myVar=new ObservableCollection<string>();
        public ObservableCollection<string> JumpListMyApp
        {
            get { return myVar; }
            set { myVar = value; }
        }        
        public ViewModel()
        {
            var jump = JumpList.GetJumpList(App.Current);
            foreach (var item in JumpList.GetJumpList(App.Current).JumpItems)
            {
                JumpTask tsk = item as JumpTask;
                JumpListMyApp.Add(tsk.Description);
            }
            
        }
    }
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            JumpTask task = new JumpTask
            {
                Title = "Check for Updates",
                Arguments = "/update",
                Description = "Cheks for Software Updates",
                CustomCategory = "Actions",
                IconResourcePath = Assembly.GetEntryAssembly().CodeBase,
                ApplicationPath = Assembly.GetEntryAssembly().CodeBase
            };
            JumpList jumpList = new JumpList();
            jumpList.JumpItems.Add(task);
            jumpList.ShowFrequentCategory = false;
            jumpList.ShowRecentCategory = false;
            JumpList.SetJumpList(Application.Current, jumpList);
        }
    }
