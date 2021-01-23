    using System;
    using System.Windows.Forms;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using Microsoft.VisualBasic;
    namespace inserting_imgs
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet ds; int rno = 0;
        MemoryStream ms;
        byte[] photo_aray;
 
        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("user id=sa;password=123;database=adil");
            loaddata();
            showdata();
        }
        void loaddata()
        {
            adapter = new SqlDataAdapter("select sno,sname,course,fee,photo from student", con);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            ds = new DataSet(); adapter.Fill(ds, "student");
        }
        void showdata()
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox1.Text = ds.Tables[0].Rows[rno][0].ToString();
                textBox2.Text = ds.Tables[0].Rows[rno][1].ToString();
                textBox3.Text = ds.Tables[0].Rows[rno][2].ToString();
                textBox4.Text = ds.Tables[0].Rows[rno][3].ToString();
                pictureBox1.Image = null;
                if (ds.Tables[0].Rows[rno][4] != System.DBNull.Value)
                {
                    photo_aray = (byte[])ds.Tables[0].Rows[rno][4];
                    MemoryStream ms = new MemoryStream(photo_aray);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            else
                MessageBox.Show("No Records");
        }
        private void browse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            } 
        }
        private void newbtn_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select max(sno)+10 from student", con);
            con.Open();
            textBox1.Text = cmd.ExecuteScalar().ToString();
            con.Close();
            textBox2.Text = textBox3.Text = textBox4.Text = "";
            pictureBox1.Image = null;
        }
        private void insert_Click(object sender, EventArgs e)
            {
                cmd = new SqlCommand("insert into student(sno,sname,course,fee,photo) values(" + textBox1.Text + ",'" + textBox2.TabIndex + "','" + textBox3.Text + "'," + textBox4.Text + ",@photo)", con);
                conv_photo();
                con.Open();
                int n = cmd.ExecuteNonQuery();
                con.Close();
                if (n > 0)
                {
                    MessageBox.Show("record inserted");
                    loaddata();
                }
            else
                MessageBox.Show("insertion failed");
        }
        void conv_photo()
        {
            //converting photo to binary data
            if (pictureBox1.Image != null)
            {
                //using FileStream:(will not work while updating, if image is not changed)
                //FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                //byte[] photo_aray = new byte[fs.Length];
                //fs.Read(photo_aray, 0, photo_aray.Length);  
 
                //using MemoryStream:
                ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                byte[] photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);
                cmd.Parameters.AddWithValue("@photo", photo_aray);
            }
        }
 
        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(Interaction.InputBox("Enter sno:", "Search", "20", 100, 100));
                DataRow drow;
                drow = ds.Tables[0].Rows.Find(n);
                if (drow != null)
                {
                    rno = ds.Tables[0].Rows.IndexOf(drow);
                    textBox1.Text = drow[0].ToString();
                    textBox2.Text = drow[1].ToString();
                    textBox3.Text = drow[2].ToString();
                    textBox4.Text = drow[3].ToString();
                    pictureBox1.Image = null;
                    if (drow[4] != System.DBNull.Value)
                    {
                        photo_aray = (byte[])drow[4];
                        MemoryStream ms = new MemoryStream(photo_aray);
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                    MessageBox.Show("Record Not Found");
            }
            catch
            {
                MessageBox.Show("Invalid Input");
            }
        }
        private void update_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update student set sname='" + textBox2.Text + "', course='" + textBox3.Text + "', fee='" + textBox4.Text + "', photo=@photo where sno=" + textBox1.Text, con);
            conv_photo();
            con.Open();
            int n = cmd.ExecuteNonQuery();
            con.Close();
            if (n > 0)
            {
                MessageBox.Show("Record Updated");
                loaddata();
            }
            else
                MessageBox.Show("Updation Failed");
        }
 
        private void delete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete from student where sno=" + textBox1.Text, con);
            con.Open();
            int n = cmd.ExecuteNonQuery();
            con.Close();
            if (n > 0)
            {
                MessageBox.Show("Record Deleted");
                loaddata();
                rno = 0;
                showdata();
            }
            else
                MessageBox.Show("Deletion Failed");
        }
        private void first_Click(object sender, EventArgs e)
        {
            rno = 0; showdata();
            MessageBox.Show("First record"); 
        }
 
        private void previous_Click(object sender, EventArgs e)
        {
 
            if (rno > 0)
            {
                rno--; showdata();
            }
            else
                MessageBox.Show("First record");
        }
        private void next_Click(object sender, EventArgs e)
        {
            if (rno < ds.Tables[0].Rows.Count - 1)
            {
                rno++; showdata();
            }
            else
                MessageBox.Show("Last record");
        }
        private void last_Click(object sender, EventArgs e)
        {
            rno = ds.Tables[0].Rows.Count - 1;
            showdata(); MessageBox.Show("Last record");
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     }
}
