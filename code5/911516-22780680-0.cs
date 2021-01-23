        xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity"
        xmlns:cmd="clr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras"
    
    <ListBox Name="ProgamsList" ItemsSource="{Binding ProgramsList}" HorizontalAlignment="Stretch" FontFamily="Portable User Interface" >
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="Loaded">
                <cmd:EventToCommand Command="{Binding LoadedCommand}" />
            </i:EventTrigger>        
        </i:Interaction.Triggers>
    </ListBox>
    
    
        public RelayCommand LoadedCommand
                {
                    get;
                    private set;
                }
        
                /// <summary>
                /// Initializes a new instance of the SplashScreenViewModel class.
                /// </summary>
                public SplashScreenViewModel()
                {
                    LoadedCommand = new RelayCommand(toDoSomehing);
                }
    
        private void toDoSomething(){
        }
