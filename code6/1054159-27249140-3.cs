    public partial class MyUserControl: UserControl
    {
        // MyEntities context; i dont need this
        public ViewMasterData()
        {
            InitializeComponent();
            // createComboBoxTable();
        }
        private void MyUserControl_Load(object sender, EventArgs e)
        {
            using (var context = new MyEntitiesContext())
            {
                createComboBoxTable(context.MyEntities.ToList());
            }
        }
        private void SaveNewMyEntity(MyEntity newEntity)
        {
            using (var context = new MyEntitiesContext())
            {
                // some logic here to check for uniqueness etc
                context.MyEntities.Add(newEntity);
                context.SaveChanges(); 
            }
        }
        private void UpdateExistingMyEntity(MyEntity updatedEntity)
        {
            using (var context = new MyEntitiesContext())
            {
                context.Entry(updatedEntity).State = EntityState.Modified;
                context.SaveChanges(); 
            }
        }
    }
