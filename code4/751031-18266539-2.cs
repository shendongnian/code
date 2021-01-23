    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.Load +=Form1_Load;
            }
            public DataGridView ViewA, ViewB;
            public DataTable DataA, DataB;
            public Button MoveSelectedFromViewAToB, MoveSelectedFromViewBToA;
            private void Form1_Load(object sender, EventArgs e)
            {
                //Create two DataGridViews on the form
                ViewA = new DataGridView()
                {
                    Location = new Point(0, 0),
                    Size = new Size(300, 100),
                    MultiSelect = false
                };
                ViewB = new DataGridView()
                {
                    Location = new Point(300, 0),
                    Size = new Size(300, 100),
                    MultiSelect = false
                };
                this.Controls.Add(ViewA);
                this.Controls.Add(ViewB);
                //Add Two buttons
                Button MoveSelectedFromViewAToB = new Button()
                {
                    Text = "A => B",
                    Location = new Point(10, 120),
                };
                MoveSelectedFromViewAToB.Click += MoveSelectedFromViewAToB_Click;
                MoveSelectedFromViewBToA = new Button()
                {
                    Text = "A <= B",
                    Location = new Point(310, 120)
                };
                MoveSelectedFromViewBToA.Click += MoveSelectedFromViewBToA_Click;
                this.Controls.Add(MoveSelectedFromViewAToB);
                this.Controls.Add(MoveSelectedFromViewBToA);
                //Make sure the form has appropriate size
                this.Size = new Size(600, 200);
                //Create a DataTable and add some data
                DataA = new DataTable();
                DataA.Columns.Add("Key", typeof(System.String));
                DataA.Columns.Add("Value", typeof(System.String));
                DataA.Rows.Add(new object[] { "KeyA", "ValueA" });
                DataA.Rows.Add(new object[] { "KeyB", "ValueB" });
                DataA.Rows.Add(new object[] { "KeyC", "ValueC" });
                DataA.Rows.Add(new object[] { "KeyD", "ValueD" });
                //Make sure DataB has the same layout as DataA
                DataB = DataA.Clone();
                //Assign both datatables to the views
                ViewA.DataSource = new BindingSource() { DataSource = DataA };
                ViewB.DataSource = new BindingSource() { DataSource = DataB };
            }
            /// <summary>
            /// Moves rows from view A to B
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void MoveSelectedFromViewAToB_Click(object sender, EventArgs e)
            {
                if (ViewA.SelectedRows.Count == 0 || DataA.Rows.Count == 0 || ViewA.SelectedRows[0].Index > DataA.Rows.Count -1) return;//No row selected, or data table is empty
                DataB.ImportRow(DataA.Rows[ViewA.SelectedRows[0].Index]);
                DataA.Rows.RemoveAt(ViewA.SelectedRows[0].Index);
            }
            /// <summary>
            /// Moves rows from view B to A
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void MoveSelectedFromViewBToA_Click(object sender, EventArgs e)
            {
                if (ViewB.SelectedRows.Count == 0 || DataB.Rows.Count == 0 || ViewB.SelectedRows[0].Index > DataB.Rows.Count -1) return; //No row selected, or data table is empty
                DataA.ImportRow(DataB.Rows[ViewB.SelectedRows[0].Index]);
                DataB.Rows.RemoveAt(ViewB.SelectedRows[0].Index);
            }
        }
    }
