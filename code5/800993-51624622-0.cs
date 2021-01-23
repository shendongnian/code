    <!--xaml code-->
    <Grid>
    <ComboBox Name="cmbData" ItemsSource="{Binding studentInfo}"  SelectedItem="{Binding SelectedstudentInfo}" HorizontalAlignment="Left" Margin="225,150,0,0" VerticalAlignment="Top" Width="120" DisplayMemberPath="name" SelectedValuePath="id"  IsSynchronizedWithCurrentItem="True" SelectedIndex="0"/>
    <Button VerticalAlignment="Center" Margin="0,0,150,0" Height="40" Width="70" Click="Button_Click">OK</Button>
    </Grid>
    
    
    // student class
    public class Student
    {
    public  int Id { set; get; }
    public string name { set; get; }
    } 
    
    // set 2 properties in code behind
    public ObservableCollection<Student> studentInfo { set; get; }
    public Student SelectedstudentInfo { set; get; }
    
    // main window constructor
    public MainWindow()
    {
    InitializeComponent();
    bindCombo();
    this.DataContext = this;
    
    }
    //method to bind combobox , you can fetch data from database 
    public void bindCombo()
    {
    ObservableCollection<Student> studentList = new ObservableCollection<Student>();
    studentList.Add(new Student { Id = 1, name = "zoyeb" });
    studentList.Add(new Student { Id = 2, name = "siddiq" });
    studentList.Add(new Student { Id = 3, name = "James" });
    studentInfo=studentList;
    }
    
    //selected student 
    private void Button_Click(object sender, RoutedEventArgs e)
    {
    object name = SelectedstudentInfo;
    } 
