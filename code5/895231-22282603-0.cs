    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    namespace SOWinForm
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private DataGridView DataGridView1;
            private void Form1_Load(object sender, EventArgs e)
            {
                DataGridView1 = new DataGridView();
                var column = CreateComboBoxColumn();
                SetAlternateChoicesUsingDataSource(column);
                DataGridView1.Columns.Add(column);
                Controls.Add(DataGridView1); 
            }
            private DataGridViewComboBoxColumn CreateComboBoxColumn()
            {
                DataGridViewComboBoxColumn column =
                    new DataGridViewComboBoxColumn();
                {
                    column.DataPropertyName = "Name";
                    column.HeaderText = "Name";
                    column.DropDownWidth = 150;
                    column.Width = 100;
                    column.MaxDropDownItems = 3;
                    column.FlatStyle = FlatStyle.Flat;
                }
                return column;
            }
            private void SetAlternateChoicesUsingDataSource(DataGridViewComboBoxColumn comboboxColumn)
            {
                {
                    comboboxColumn.DataSource = RetrieveNames();
                    comboboxColumn.ValueMember = "Name";
                    comboboxColumn.DisplayMember = comboboxColumn.ValueMember;
                }
            }
            private List<Student> RetrieveNames()
            {
                return new List<Student>() { new Student() { Name = "Rohan" }, new Student() { Name = "Ram" } };
            }
        }
        public class Student
        {
            public string Name { get; set; }
        }
    }
