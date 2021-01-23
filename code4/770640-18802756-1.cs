       using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;
    using StackOverFlowTestApp.Resources;
    using Microsoft.Phone.Tasks;
    using Microsoft.Phone.UserData;
    
    namespace StackOverFlowTestApp
    {
        public partial class MainPage : PhoneApplicationPage
        {
            private SaveAppointmentTask saveAppointmentTask;
            private List<int> listMinutes = new List<int>();
            // Constructor
            public MainPage()
            {
                InitializeComponent();
                List<User> list = new List<User>();
                for (int i = 0; i < 10; i++) {
                    User user = new User();
                    user.name = "Anobik"+i;
                    list.Add(user);
                }
                NameList.ItemsSource = list;
            }
    
    
        }
    
    
        public class User {
            public string name { get; set; }
        }
    
    
    }
