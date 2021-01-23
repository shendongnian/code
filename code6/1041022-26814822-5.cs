    public ShellViewModel(/*IEnumerable<Screen> screens*/){  // Not Necessary 
         //automatically finds what is in the IoC Container 
         //(MEF, SimpleContainer, AutoFac, StructureMap etc... 
         //Assuming your using one...
         //this.Items.AddRange(screens);
          this.Items.Add(new ProjectViewModel(new Project(){ ProjectName = "Test";}));   
    }
    protected override OnInitialize(){
    }
