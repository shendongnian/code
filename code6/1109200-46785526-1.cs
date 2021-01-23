    public partial class Student_Details : ContentPage
    {
        public Student_Details(int id)
        {
            InitializeComponent();
            Task.Run(async () => await getStudent(id));
        }
        public async Task<int> getStudent(int id)
        {
            Student _student;
            SQLiteDatabase db = new SQLiteDatabase();
            _student = await db.getStudent(id);
            return 0;
        }
    }
