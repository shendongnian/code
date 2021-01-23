            ViewModel -> VMStudent.cs
            
            using GalaSoft.MvvmLight;
            using GalaSoft.MvvmLight.Command;
            using System;
            using System.Collections.Generic;
            using System.Collections.ObjectModel;
            using System.ComponentModel;
            using System.Linq;
            using System.Text;
            using System.Text.RegularExpressions;
            using System.Threading.Tasks;
            using System.Windows;
            using WpfDesktopCrud.Model;
            
            namespace WpfDesktopCrud.ViewModel
            {
                class VMStudent : ViewModelBase, IDataErrorInfo
                {
                    public VMStudent()
                    {
                        try
                        {
            
                            Students = new ObservableCollection<Student>();
                            Students.Add(new Student { id = 1, name = "Dhru", mobno = "0000000000", address = "Shahibaug", email = "dhrusoni84@gmail.com" });
                            Students.Add(new Student { id = 2, name = "Soni", mobno = "9033259059", address = "Vastrapur", email = "dhru_soni@yahoo.com" });
                            SaveCommand = new RelayCommand(Save);
                            NewCommand = new RelayCommand(New);
                            DeleteCommand = new RelayCommand(Delete);
                            PropertyChanged += VMStudent_PropertyChanged;
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
            
                    void VMStudent_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
                    {
                        switch (e.PropertyName)
                        {
                            case "Selected":
                                if (Selected != null)
                                {
                                    ID = Selected.id;
                                    Name = Selected.name;
                                    MobileNo = Selected.mobno;
                                    Address = Selected.address;
                                    Email = Selected.email;
            
                                }
                                break;
                        }
                    }
            
                    #region Properties
            
                    private ObservableCollection<Student> _Students;
            
                    public ObservableCollection<Student> Students
                    {
                        get { return _Students; }
                        set
                        {
                            _Students = value;
                            RaisePropertyChanged("Students");
                        }
                    }
            
                    private Student _Selected;
            
                    public Student Selected
                    {
                        get { return _Selected; }
                        set
                        {
                            _Selected = value;
                            RaisePropertyChanged("Selected");
                        }
                    }
            
                    private int _ID;
            
                    public int ID
                    {
                        get { return _ID; }
                        set
                        {
                            _ID = value;
                            RaisePropertyChanged("ID");
                        }
                    }
            
                    private string _Name;
            
                    public string Name
                    {
                        get { return _Name; }
                        set
                        {
                            _Name = value;
                            RaisePropertyChanged("Name");
                        }
                    }
            
                    private string _MobileNo;
            
                    public string MobileNo
                    {
                        get { return _MobileNo; }
                        set
                        {
                            _MobileNo = value;
                            RaisePropertyChanged("MobileNo");
                        }
                    }
                    private string _Address;
            
                    public string Address
                    {
                        get { return _Address; }
                        set
                        {
                            _Address = value;
                            RaisePropertyChanged("Address");
                        }
                    }
                    private string _Email;
            
                    public string Email
                    {
                        get { return _Email; }
                        set
                        {
                            _Email = value;
                            RaisePropertyChanged("Email");
                        }
                    }
            
            
                    #endregion
            
                    #region Commands
            
                    public RelayCommand SaveCommand { get; set; }
            
                    public RelayCommand NewCommand { get; set; }
            
                    public RelayCommand DeleteCommand { get; set; }
            
                    #endregion
            
                    #region Methods
                    public void Save()
                    {
                        if (Selected != null)
                        {
                            if (Selected.id != 0)
                            {
                                Selected.name = this.Name;
                                Selected.mobno = this.MobileNo;
                                Selected.address = this.Address;
                                Selected.email = this.Email;
                                MessageBox.Show("Record Updated.", "WPF MVVM", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                                this.ID = 0;
                                this.Name = string.Empty;
                                this.Address = string.Empty;
                                this.MobileNo = string.Empty;
                                this.Email = string.Empty;
            
                            }
                        }
                        else
                        {
                            try
                            {
            
                                Students.Add(new Student { id = Students.Count + 1, name = this.Name, mobno = this.MobileNo, address = this.Address, email = this.Email });
                                MessageBox.Show("Record Saved.", "WPF MVVM", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                                this.ID = 0;
                                this.Name = string.Empty;
                                this.MobileNo = string.Empty;
                                this.Address = string.Empty;
                                this.Email = string.Empty;
                            }
                            catch (Exception ex)
                            {
                                throw;
                            }
                        }
                    }
            
                    public void New()
                    {
                        if (Selected != null)
                        {
                            this.ID = 0;
                            this.Name = string.Empty;
                            this.MobileNo = string.Empty;
                            this.Address = string.Empty;
                            this.Email = string.Empty;
            
                            Selected.id = 0;
                        }
                        Selected = null;
                    }
            
                    public void Delete()
                    {
                        try
                        {
                            Students.Remove(Selected);
                            this.Name = string.Empty;
                            this.MobileNo = string.Empty;
                            this.Address = string.Empty;
                            this.Email = string.Empty;
                            MessageBox.Show("Record Deleted.", "WPF MVVM", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                        }
                        catch (Exception ex)
                        {
            
                            throw;
                        }
                    }
                    #endregion
            
            
            
                    public string Error
                    {
                        get { throw new NotImplementedException(); }
                    }
            
                    public string this[string columnName]
                    {
                        get
                        {
                            string result = null;
                            if (columnName == "Name")
                            {
                                if (string.IsNullOrEmpty(Name))
                                {
                                    result = "Name Cannot Be Empty";
                                    return result;
                                }
                                string st = @"!|@|#|\$|%|\?|\>|\<|\*";
                                if (Regex.IsMatch(Name, st))
                                {
                                    result = "special chatachter are not allowed";
                                    return result;
                                }
            
            
                            }
            
                            if (columnName == "MobileNo")
                            {
                                if (string.IsNullOrEmpty(MobileNo))
                                {
                                    result = "Mobile Can not be empty";
                                    return result;
                                }
                                if (MobileNo.Length > 10 || MobileNo.Length < 10)
                                {
                                    result = "number should be 10 charachters";
                                    return result;
                                }
                                string s1 = @"^[0-9]*$";
                                if (!Regex.IsMatch(MobileNo, s1))
                                {
                                    result = "Mobile number contain numeric value ";
                                    return result;
                                }
                                else
                                {
                                    return null;
                                }
            
                            }
            
                            if (columnName == "Address")
                            {
                                if (string.IsNullOrEmpty(Address))
                                {
                                    result = "fill your address";
                                    return result;
                                }
                            }
                            if (columnName == "Email")
                            {
                                string s1 = @"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
            
                                if (string.IsNullOrEmpty(Email))
                                {
                                    result = "Email can not be empty";
                                    return result;
                                }
                                if (Regex.IsMatch(Email, s1)) //|| Regex.IsMatch(Email, s2))
                                {
                                    return null;
                                }
                                else
                                {
                                    result = "Not valid email(format: dhru@gmail.com)";
                                    return result;
            
                                }
                            }
            
                            return null;
            
                        }
                    }
                }
            }
        
        View - > Student.xaml
        
        <Window x:Class="WpfDesktopCrud.View.Students"
                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                xmlns:VM="clr-namespace:WpfDesktopCrud.ViewModel"
                Title="Students" Height="400" Width="500">
            <Window.DataContext>
                <VM:VMStudent/>
            </Window.DataContext>
        
            <Grid>
                <Grid.Resources>
                    <ControlTemplate x:Key="dTemplate">
                        <StackPanel Orientation="Horizontal">
                            <DockPanel LastChildFill="True">
                                <TextBlock DockPanel.Dock="Right" Text="{Binding AdornedElement.(Validation.Errors).[0].ErrorContent, ElementName=ErrorAdorner}" Background="#FA5858" Foreground="White" FontWeight="Light" VerticalAlignment="Center"/>
                                <AdornedElementPlaceholder VerticalAlignment="Top" x:Name="ErrorAdorner">
                                    <Border BorderBrush="Red" BorderThickness="1" />
                                </AdornedElementPlaceholder>
                            </DockPanel>
                        </StackPanel>
                    </ControlTemplate>
                </Grid.Resources>
                <Grid.RowDefinitions>
                    <RowDefinition Height="*"/>
                    <RowDefinition Height="auto"/>
                    <RowDefinition Height="Auto"/>
                </Grid.RowDefinitions>
        
                <ListBox ItemsSource="{Binding Students}" SelectedItem="{Binding Selected}" DisplayMemberPath="name"  SelectedValuePath="id" Margin="0,0,0,26">
                    
                </ListBox>
        
                <Grid Grid.Row="1" HorizontalAlignment="Center">
                    <Grid.Resources>
                        <Style TargetType="TextBlock">
                            <Setter Property="Margin" Value="5 2 5 0"/>
                            <Setter Property="HorizontalAlignment" Value="Right"/>
                        </Style>
                        <Style TargetType="TextBox">
                            <Setter Property="Margin" Value="5 5 5 5"/>
                        </Style>
                    </Grid.Resources>
                    <Grid.RowDefinitions>
                        <RowDefinition/>
                        <RowDefinition/>
                        <RowDefinition/>
                        <RowDefinition/>
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition Width="200"/>
                    </Grid.ColumnDefinitions>
                    <TextBlock Text="Name"/>
                    <TextBlock Text="Mobile No" Grid.Row="1"/>
                    <TextBlock Text="Address" Grid.Row="2"/>
                    <TextBlock Text="Email" Grid.Row="3"/>
                    <TextBox x:Name="txtName" Text="{Binding Name,UpdateSourceTrigger=PropertyChanged,Mode=TwoWay,ValidatesOnDataErrors=True}" Validation.ErrorTemplate="{StaticResource dTemplate}"
                             Grid.Column="1"/>
                    <TextBox x:Name="txtNo" Text="{Binding MobileNo,UpdateSourceTrigger=PropertyChanged,Mode=TwoWay,ValidatesOnDataErrors=True}" Validation.ErrorTemplate="{StaticResource dTemplate}"
                             Grid.Row="1" Grid.Column="1"/>
                    <TextBox x:Name="txtAdd" Text ="{Binding Address,UpdateSourceTrigger=PropertyChanged,Mode=TwoWay,ValidatesOnDataErrors=True}" Validation.ErrorTemplate="{StaticResource dTemplate}"
                             Grid.Row="2" Grid.Column="1" TextWrapping="WrapWithOverflow" AcceptsReturn="True" ScrollViewer.CanContentScroll="True" VerticalScrollBarVisibility="Auto" Height="90"/>
                    <TextBox x:Name="txtEmail" Text ="{Binding Email,UpdateSourceTrigger=PropertyChanged,Mode=TwoWay,ValidatesOnDataErrors=True}" Validation.ErrorTemplate="{StaticResource dTemplate}"
                             Grid.Row="3" Grid.Column="1"/>
                </Grid>
        
                <WrapPanel Grid.Row="3" HorizontalAlignment="Center" >
                    <Button Command="{Binding NewCommand}" Content="New" Width="75" Height="31">
                        <Button.Style>
                            <Style TargetType="{x:Type Button}">
                                <EventSetter Event="Click" Handler="MoveFocusOnClick"/>
                            </Style>
                        </Button.Style>
                    </Button>
                    <Button Command="{Binding SaveCommand}" Content="Save" Width="75" Height="31">
                        <Button.Style>
                            <Style TargetType="Button">
                                <Setter Property="IsEnabled" Value="False"/>
                                <Style.Triggers>
                                    <MultiDataTrigger>
                                        <MultiDataTrigger.Conditions>
                                            <Condition Binding ="{Binding Path=(Validation.HasError),ElementName=txtName}" Value="false"/>
                                            <Condition Binding ="{Binding Path=(Validation.HasError),ElementName=txtNo}" Value="false"/>
                                            <Condition Binding ="{Binding Path=(Validation.HasError),ElementName=txtAdd}" Value="false"/>
                                            <Condition Binding ="{Binding Path=(Validation.HasError),ElementName=txtEmail}" Value="false"/>
                                        </MultiDataTrigger.Conditions>
                                        <Setter Property="IsEnabled" Value="True"/>
                                    </MultiDataTrigger>
                                </Style.Triggers>
                            </Style>
                        </Button.Style>
                    </Button>
                    <Button Command="{Binding DeleteCommand}" Content="Delete" Width="75" Height="31"/>
                </WrapPanel>
            </Grid>
        </Window>
    
    
    Model -> Student.cs
    using GalaSoft.MvvmLight;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace WpfDesktopCrud.Model
    {
        class Student : ViewModelBase
        {
            private int _id;
    
            public int id
            {
                get { return _id; }
                set
                {
                    _id = value;
                    RaisePropertyChanged("id");
                }
            }
            private string _name;
    
            public string name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    RaisePropertyChanged("name");
                }
            }
            private string _mobno;
    
            public string mobno
            {
                get { return _mobno; }
                set
                {
                    _mobno = value;
                    RaisePropertyChanged("mobno");
                }
            }
            private string _address;
    
            public string address
            {
                get { return _address; }
                set
                {
                    _address = value;
                    RaisePropertyChanged("address");
                }
            }
            private string _email;
    
            public string email
            {
                get { return _email; }
                set
                {
                    _email = value;
                    RaisePropertyChanged("email");
                }
            }
    
    
    
            private DateTime _timer;
            public DateTime Timer
            {
                get { return _timer; }
                set
                {
                    _timer = value;
                    RaisePropertyChanged("timer");
                }
            }
    
    
        }
    }
