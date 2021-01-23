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
