    public partial class MainWindow 
    {
        MakeStuffHappen helper = null;
        public MainWindow()
        { 
           OnInitialized += (s,e)=> { helper = new MakeStuffHappen(this.MyGridName); } 
        }
    }
