    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace automaticallyexpanddatagridviewsizeandformsize
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
              //  MessageBox.Show(dataGridView1.Size.Width.ToString());
    
                // note that with these two set you can't change the width of a column
                // also  MininimumWidth would limit changing the width of a column too, 
                //http://stackoverflow.com/questions/2154154/datagridview-how-to-set-column-width
                // but that doesn't matter because we aren't programmatically changing the width of any column.
                
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; 
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    
    
    
    
            }
    
    
    
            private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
    
                int olddgvsize = dataGridView1.Width;
    
                textBox1.Text = dataGridView1.Columns[0].Width.ToString();
                int h=dataGridView1.Height;
    
                int tw = 0;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                  //  MessageBox.Show(dataGridView1.Columns[i].Width.ToString());
                    tw += dataGridView1.Columns[i].Width;
    
                }
                tw += 50; // column before col 0..
    
               //you only need one of these.
               //though to better understand the code you can try to comment out both and see how the total width of all columns (tw)(+50) so ALL the columns, differs from  the DataGridView.Width (the total area which includes all columns plus some grey if it's much bigger than all the columns)
                dataGridView1.Size = new Size(tw, h);
                dataGridView1.Width = tw;
    
                    textBox1.Text = "tw=" + tw + " " + "dgvw=" + " " +dataGridView1.Width+ "  "+"col 1:" + dataGridView1.Columns[0].Width + " col 2:"  + dataGridView1.Columns[1].Width + " col 3:"+ dataGridView1.Columns[2].Width;
    
                    int newdgvsize = dataGridView1.Width;
                    int differenceinsizeofdgv = newdgvsize - olddgvsize;
                    this.Width = this.Width + differenceinsizeofdgv;
    
    
            }
    
            
        }
    
     
    
    }
