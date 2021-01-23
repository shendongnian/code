    <!-- xaml code-->
        <Grid>
            <ComboBox Name="cmbData"    SelectedItem="{Binding SelectedstudentInfo, Mode=OneWayToSource}" HorizontalAlignment="Left" Margin="225,150,0,0" VerticalAlignment="Top" Width="120" DisplayMemberPath="name" SelectedValuePath="id" SelectedIndex="0" />
            <Button VerticalAlignment="Center" Margin="0,0,150,0" Height="40" Width="70" Click="Button_Click">OK</Button>
        </Grid>
    	
    	   
    
            //student Class
            public class Student
            {
                public  int Id { set; get; }
                public string name { set; get; }
            }
    
            //set 2 properties in MainWindow.xaml.cs Class
            public ObservableCollection<Student> studentInfo { set; get; }
            public Student SelectedstudentInfo { set; get; }
            
            //MainWindow.xaml.cs Constructor
            public MainWindow()
            {
                InitializeComponent();
                bindCombo();
                this.DataContext = this;
                cmbData.ItemsSource = studentInfo;
               
            }
            
            //method to bind cobobox or you can fetch data from database in MainWindow.xaml.cs
            public void bindCombo()
            {
                ObservableCollection<Student> studentList = new ObservableCollection<Student>();
                studentList.Add(new Student { Id=0 ,name="==Select=="});
                studentList.Add(new Student { Id = 1, name = "zoyeb" });
                studentList.Add(new Student { Id = 2, name = "siddiq" });
                studentList.Add(new Student { Id = 3, name = "James" });
                
                  studentInfo=studentList;
                
            }
    
            //button click to get selected student MainWindow.xaml.cs
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Student student = SelectedstudentInfo;
                if(student.Id ==0)
                {
                    MessageBox.Show("select name from dropdown");
                }
                else
                {
                    MessageBox.Show("Name :"+student.name + "Id :"+student.Id);
                }
            }
