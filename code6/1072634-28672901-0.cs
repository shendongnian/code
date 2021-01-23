    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;
    namespace XamLab1
    {
        public class ViewModelMain
        {
            public ObservableCollection<ViewModelA> AItems { get; set; }
            public ObservableCollection<ViewModelB> AllBItems { get; set; } 
            public ViewModelMain()
            {
                AItems = new ObservableCollection<ViewModelA>();
                AllBItems = new ObservableCollection<ViewModelB>();
                this.UpdateCommand = new Command<string>((key) =>
                {
                    Update();
                });
            }
            public ICommand UpdateCommand { protected set; get; }
            public void Update()
            {
                // filling collections with dummy test data...
                AItems.Clear();
                AllBItems.Clear();
                for (int i = 0; i < 10; i++)
                {
                    long timestamp = DateTime.Now.Ticks;
                    var a = new ViewModelA("A-" + i + "-" + timestamp, AllBItems);
                    AItems.Add(a);
                    for (int j = 0; j < 3; j++)
                    {
                        AllBItems.Add(new ViewModelB { NameB = "B-" + i + "-" + j + "-" + timestamp, Parent = a });
                    }
                }            
            }
        }
    }
