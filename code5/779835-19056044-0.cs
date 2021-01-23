    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    using System.IO;
    using System.Data.SqlClient;
    
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private string _path;
    
            SqlConnection cnn = new SqlConnection("Initial Catalog=randomcompany;Data Source=localhost;Integrated Security=SSPI;");
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
    
            private void button2_Click(object sender, EventArgs e) //Browse button
            {
                try
                {
                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";
                    dlg.Title = "Select Employee Picture";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image = System.Drawing.Image.FromFile(dlg.FileName);
                        _path = dlg.FileName;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
    
            private void button1_Click(object sender, EventArgs e) //Save button
            {
    
                try
                {
                    cnn.Open();
                    Byte[] imagedata = File.ReadAllBytes(_path);
                    SqlCommand cmd = new SqlCommand("INSERT INTO Employees (EmployeeFirstname, EmployeeLastname, EmployeePhoto) VALUES (@item1,@item2,@img", cnn);
                    cmd.Parameters.AddWithValue("@item1", textBox1.Text);
                    cmd.Parameters.AddWithValue("@item2", textBox2.Text);
                    cmd.Parameters.AddWithValue("@img", imagedata);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
    
            }
    
        }
    }
