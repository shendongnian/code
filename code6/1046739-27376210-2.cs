    public partial class Window_NewWorkoutLine : Window
    {
        private List<InformationValueObject> _valueObjects = new List<InformationValueObject>();
        public Window_NewWorkoutLine(int NoOfSets, int workoutLineId)
        {
            InitializeComponent();
    
            currentWorkoutLineId = workoutLineId;
    
            for (int x = 1; x <= NoOfSets; x++)
            {
                SetInformation setInformation = new SetInformation(x);
                InformationValueObject vo = new InformationValueObject();
                setInformation.DataContext = _vo;
                _valueObjects.Add(vo);
                StackPanel_Main.Children.Add(setInformation);
            }
        }
    }  
