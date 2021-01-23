    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
          Student std = new Student {Name = "Vimal" , Phone = "PhoneValue", Email="mymail",Age=24};
          propertyGrid1.SelectedObject= std;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.Rows.Count - 1;
            Student std = (Student)propertyGrid1.SelectedObject;
            dataGridView1.Rows[index].Cells["Name"].Value = std.Name;
            dataGridView1.Rows[index].Cells["Age"].Value = std.Age;
            dataGridView1.Rows[index].Cells["Email"].Value = std.Email;
            dataGridView1.Rows[index].Cells["Phone"].Value = std.Phone;
        }
    }
    public class Student
    {
        public int Age { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
