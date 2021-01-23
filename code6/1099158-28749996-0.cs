    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace winFormDataGridViewTransparentAndImage
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            /*
                VB olan bu kodu C# internetteki convert siteleri sayesinde çevirdim
                Ancak yeterli olmadı hata alıyordu nedeni bunu Form1.Designer.cs den
                itibaren başlayan bir class olayı olduğu için. Nesne oluşturulurken
                bizim verdiğimiz özelliklere göre oluşturulması gerekiyordu.
                Neyse uzatmadan baya zaman harcadım C# çevirmek ve doğru istenilen
                amaca ulaşmak için ama sonunda başarmak önemli adımlarımdan biri oldu.
                
                #Murat Çakmak (Dikey)         
             */
    
            private void Form1_Load(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Columns1");
                dt.Columns.Add("Columns2");
    
                dt.Rows.Add("Rows1", "Rows1");
                dt.Rows.Add("Rows2", "Rows2");
                dataGridView1.DataSource = dt;
                dataGridView2.DataSource = dt;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                dataGridView1.Size = new Size(0,0);
                dataGridView2.Size = new Size(0,0);
                dataGridView1.Size = new Size(350, 350);
                dataGridView2.Size = new Size(350, 350);
            }
        }
    }
