    public class Employee
    {
        public string id { get; set; }
        public string name { get; set; }
        public string imagePath { get; set; }
    }
    
    private void bindGrid()
    {
        List<Employee> employees = new List<Employee>();
        employees.Add(new Employee() {  id = "1",name = "joseph", imagePath = "abc.png" });
        employees.Add(new Employee() {  id = "2", name = "Mac", imagePath = "capture2.png" });
        this.dataGridView1.DataSource = employees;
       
        DataGridViewImageColumn column = new DataGridViewImageColumn();
        column.Name = "imgColumn1";
        column.HeaderText = "Image";
        this.dataGridView1.Columns.Add(column);
        this.dataGridView1.Refresh();
        foreach (DataGridViewRow row1 in dataGridView1.Rows)
        {
            string imgPath;
            imgPath = Path.Combine(Application.StartupPath, row1.Cells[2].Value.ToString());
            Image imageFile = Image.FromFile(imgPath);
            if (imgPath != null)
            {
                row1.Cells[3].Value = imageFile;
            }
            else
            {
                MessageBox.Show("Invalid Path");
            }
        }
    }
