    private SaveAppointmentTask saveAppointmentTask;
        private List<int> listMinutes = new List<int>();
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++) {
                listMinutes.Add(i);
            }
        }
        int countAdded = 0;
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            
            if (countAdded < 10)
            {
                
                saveAppointmentTask = new SaveAppointmentTask();
                saveAppointmentTask.StartTime = DateTime.Now.AddMinutes(listMinutes[countAdded]);
                saveAppointmentTask.EndTime = saveAppointmentTask.StartTime.Value.AddMinutes(2);
                saveAppointmentTask.Subject = "Meet Ali"; // appointment subject
                saveAppointmentTask.Location = "In Office"; // appointment location
                saveAppointmentTask.Details = "Meet Ali to discuss product launch";//appointment details
                saveAppointmentTask.IsAllDayEvent = false;
                saveAppointmentTask.Reminder = Microsoft.Phone.Tasks.Reminder.FifteenMinutes;
                saveAppointmentTask.AppointmentStatus = Microsoft.Phone.UserData.AppointmentStatus.OutOfOffice;
                countAdded++;
                saveAppointmentTask.Show();
            }
            else { 
                // do not add anything
            }
        }
