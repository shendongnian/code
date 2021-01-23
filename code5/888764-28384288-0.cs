    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using MahApps.Metro.Controls;
    using MahApps.Metro.Controls.Dialogs;
    
    namespace Busyboy
    {
        [Export(typeof(IShell))]
        class MainViewModel : PropertyChangedBase, IShell
        {
            public void StartPomodoro()
            {
                var mainview0 = System.Windows.Application.Current.Windows.OfType<MainView>().FirstOrDefault();
                mainview0.ShowInputAsync("New Pomodoro", "Enter a name for new pomodoro session.");
            }
        }
    }
