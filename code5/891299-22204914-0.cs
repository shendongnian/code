        I tried something with i know and i got output just as your requirement.Please correct me if i'm wrong.  
        
     My Xaml:
    
     <Window x:Class="MVVM_sample_ListBox.MainWindow"
                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                xmlns:local="clr-namespace:MVVM_sample_ListBox"
                Title="MainWindow" Height="350" Width="525"
                xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity">
            <Window.Resources>
                <local:Converter x:Key="Converter"/>
            </Window.Resources>    <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="235*" />
                    <ColumnDefinition Width="268*" />
                </Grid.ColumnDefinitions>
                <ListBox x:Name="lb"  SelectionMode="Multiple" Grid.Row="0"  ItemsSource="{Binding MyCollection}">
                    <i:Interaction.Triggers>
                        <i:EventTrigger EventName="MouseUp" >
                            <i:InvokeCommandAction CommandParameter="{Binding SelectedItems, ElementName=lb}" Command="{Binding SelectionChangedCommand}"/>
                        </i:EventTrigger>
                    </i:Interaction.Triggers>
                    <ListBox.ItemTemplate>
                        <DataTemplate>
                            <StackPanel>
                                <TextBlock Text="{Binding FirstName}"/>
                                <TextBlock Text="{Binding SecondName}"/>
                                <TextBlock Text="{Binding Company}"/>
                                
                            </StackPanel>
                        </DataTemplate>
                    </ListBox.ItemTemplate>
                </ListBox>
                <StackPanel Grid.Column="1" >
                    <TextBox Grid.Column="1" Height="23" HorizontalAlignment="Left" Text="{Binding SelectedItem,ConverterParameter=FName, Converter={StaticResource Converter}}" Name="textBox1" VerticalAlignment="Top" Width="120" />
                    <TextBox Grid.Column="1" Height="23" HorizontalAlignment="Left" Text="{Binding SelectedItem,ConverterParameter=SName, Converter={StaticResource Converter}}" Name="textBox2" VerticalAlignment="Top" Width="120" />
                    <TextBox Grid.Column="1" Height="23" HorizontalAlignment="Left" Text="{Binding SelectedItem,ConverterParameter=Comp, Converter={StaticResource Converter}}" Name="textBox3" VerticalAlignment="Top" Width="120" />
                </StackPanel>
            </Grid>
        </Window>
    
        
        
        
        My C# Code:
     
    
        public partial class MainWindow : Window
            {
                public MainWindow()
                {
                    InitializeComponent();
                    this.DataContext = new ViewModel();
                }
        
            }
            public class Model : INotifyPropertyChanged
            {
                private string fname;
        
                public string FirstName
                {
                    get { return fname; }
                    set { fname = value;RaisePropertyChanged("FirstName"); }
                }
        
                private string sname;
        
                public string SecondName
                {
                    get { return sname; }
                    set { sname = value; RaisePropertyChanged("SecondName");}
                }
        
                private string company;
        
                public string Company
                {
                    get { return company; }
                    set { company = value;RaisePropertyChanged("Company"); }
                }
        
        
                public event PropertyChangedEventHandler PropertyChanged;
                private void RaisePropertyChanged(string name)
                {
                    if(PropertyChanged!= null)
                    {
                        this.PropertyChanged(this,new PropertyChangedEventArgs(name));
                    }
                }
            }
            public class ViewModel : INotifyPropertyChanged
            {
                private MyCommand selectionChangedCommand;
        
                public MyCommand SelectionChangedCommand
                {
                    get 
                    {
                        if (selectionChangedCommand == null)
                        {
                            selectionChangedCommand = new MyCommand(SelectionChanged);
                        }
                        return selectionChangedCommand;
                    }
                    set { selectionChangedCommand = value; }
                }
                public void SelectionChanged(object value)
                {
                    SelectedItem = new ObservableCollection<Model>((value as IEnumerable).OfType<Model>());
                }
               
        
                private ObservableCollection<Model> selectedItem;
        
                public ObservableCollection<Model> SelectedItem
                {
                    get { return selectedItem; }
                    set { selectedItem = value; RaisePropertyChanged("SelectedItem"); }
                }
        
                private ObservableCollection<Model> mycoll;
        
        	public ObservableCollection<Model> MyCollection
        	{
        		get { return mycoll;}
        		set { mycoll = value;}
        	}
                public ViewModel()
                {
                    SelectedItem = new ObservableCollection<Model>();
                    SelectedItem.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(SelectedItem_CollectionChanged);
                    MyCollection = new ObservableCollection<Model>();
                    MyCollection.Add(new Model { FirstName = "aaaaa", SecondName = "bbbbb", Company = "ccccccc" });
                    MyCollection.Add(new Model { FirstName = "ddddd", SecondName = "bbbbb", Company = "eeeeeee" });
                    MyCollection.Add(new Model { FirstName = "fffff", SecondName = "gggggg", Company = "ccccccc" });
        
                }
        
                void SelectedItem_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    //this.SelectedItem =new ObservableCollection<Model>((sender as ObservableCollection<Model>).Distinct());
                }
                public event PropertyChangedEventHandler PropertyChanged;
                private void RaisePropertyChanged(string name)
                {
                    if(PropertyChanged!= null)
                    {
                        this.PropertyChanged(this,new PropertyChangedEventArgs(name));
                    }
                }
            }
            public class MyCommand : ICommand
            {
                private Action<object> _execute;
        
                private Predicate<object> _canexecute;
        
                public MyCommand(Action<object> execute, Predicate<object> canexecute)
                {
                    _execute = execute;
                    _canexecute = canexecute;
                }
        
                public MyCommand(Action<object> execute)
                    : this(execute, null)
                {
                    _execute = execute;
                }
        
                #region ICommand Members
        
                public bool CanExecute(object parameter)
                {
                    if (parameter == null)
                        return true;
                    if (_canexecute != null)
                    {
                        return _canexecute(parameter);
                    }
                    else
                    {
                        return true;
                    }
        
                }
        
                public event EventHandler CanExecuteChanged
                {
                    add { CommandManager.RequerySuggested += value; }
                    remove { CommandManager.RequerySuggested -= value; }
                }
        
        
                public void Execute(object parameter)
                {
                    _execute(parameter);
                }
        
                #endregion
            }
            public class Converter : IValueConverter
            {
                ObservableCollection<Model> mycollection;
                public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    var coll = (ObservableCollection<Model>)value;
                    mycollection = coll;
                    if (coll.Count == 1)
                    {
                        if (parameter.ToString() == "FName")
                            return coll[0].FirstName;
                        else if (parameter.ToString() == "SName")
                            return coll[0].SecondName;
                        else if (parameter.ToString() == "Comp")
                            return coll[0].Company;
                    }
                    else if(coll.Count >1)
                    {
                       // string name = coll[0].FirstName;
                        if (parameter.ToString() == "FName")
                        {
                            string name = coll[0].FirstName;
                            foreach (var c in coll)
                            {
                                if (c.FirstName != name)
                                    return null;
                                else continue;
                            }
                            return name;
                        }
                        if (parameter.ToString() == "SName")
                        {
                            string name = coll[0].SecondName;
                            foreach (var c in coll)
                            {
                                if (c.SecondName != name)
                                    return null;
                                else continue;
                            }
                            return name;
                        }
                        if (parameter.ToString() == "Comp")
                        {
                            string name = coll[0].Company;
                            foreach (var c in coll)
                            {
                                if (c.Company != name)
                                    return null;
                                else continue;
                            }
                            return name;
                        }
                    }
                    return null;
                }
        
                public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    
                    if (parameter.ToString() == "FName")
                    {
                        foreach (var c in mycollection)
                        {
                            c.FirstName = value.ToString();
                        }
                        return mycollection;
                    }
                    else
                    if (parameter.ToString() == "SName")
                    {
                        foreach (var c in mycollection)
                        {
                            c.SecondName = value.ToString();
                        }
                        return mycollection;
                    }
                    else
                    if (parameter.ToString() == "Comp")
                    {
                        foreach (var c in mycollection)
                        {
                            c.Company = value.ToString();
                        }
                        return mycollection;
                    }
                    return null;
                }
            }
    
        
        Regards,
        Kumar
