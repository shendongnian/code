    public ShellViewModel(IEnumerable<Screen> screens){
         //automatically finds what is in the IoC Container 
         //(MEF, SimpleContainer, AutoFac, StructureMap etc... 
         //Assuming your using one...
          this.Items.AddRange(screens);   
    }
    protected override OnInitialize(){
    }
