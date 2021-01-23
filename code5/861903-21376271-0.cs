    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace Time_Table
    {
        public partial class timetable : Form
        {
            public timetable()
            {
                InitializeComponent();
            }
    
    
            public void FillDataGrid()
            {
                string term_id = this.comboBox1.SelectedValue.ToString();
                string day_id = this.comboBox2.SelectedValue.ToString();
                string hour_id;
                string class_id;
    
                string query;
    
                DataTable result;
    
                for (int rowcounter = 0; rowcounter < this.dataGridViewX1.Rows.Count; rowcounter++)
                {
                    for (int columncounter = 1; columncounter < this.dataGridViewX1.Columns.Count; columncounter++)
                    {
                        class_id = this.dataGridViewX1.Rows[rowcounter].Cells[0].Tag.ToString();
                        hour_id = this.dataGridViewX1.Columns[columncounter].Name;
    
                        query = string.Format("SELECT * FROM timetable WHERE time_table_term_id={0} " +
                            "AND time_table_day_id={1} AND time_table_hour_id={2} AND time_table_class_id={3}", term_id, day_id, hour_id, class_id);
    
                        result = CrudClass.SelectAll(query, "timetable");
    
                        if (result.Rows.Count > 0)
                        {
                            query = string.Format("SELECT teacher_name,lesson_name FROM timetable,teachers,lessons WHERE time_table_term_id={0} " +
                            "AND time_table_day_id={1} AND time_table_hour_id={2} AND time_table_class_id={3} AND time_table_teacher_id = teacher_id AND time_table_lesson_id=lesson_id"
                            , term_id, day_id, hour_id, class_id);
    
                            result = CrudClass.SelectByQuery(query);
    
                            this.dataGridViewX1.Rows[rowcounter].Cells[columncounter].Value = result.Rows[0].ItemArray[1].ToString() + " / "
                                                                                              + result.Rows[0].ItemArray[0].ToString();
    
                            this.dataGridViewX1.Rows[rowcounter].Cells[columncounter].Style.BackColor = Color.GreenYellow;
                        }
                        else {
                            this.dataGridViewX1.Rows[rowcounter].Cells[columncounter].Style.BackColor = Color.Red;
                        }
    
                    }
                }
            }
    
    
            private void timetable_Load(object sender, EventArgs e)
            {
                DataTable ClassNames ;
                DataTable HourNames ;
    
                ClassNames = CrudClass.SelectAll("SELECT * FROM classes", "classes");
                HourNames = CrudClass.SelectAll("SELECT * FROM hours", "hours");
    
                
                this.dataGridViewX1.Columns.Add("empty", "ساعت/نام کلاس");
    
                for (int i = 0; i < HourNames.Rows.Count; i++)
                {
                    dataGridViewX1.Columns.Add(new DataGridViewTextBoxColumn() { Name=HourNames.Rows[i].ItemArray[0].ToString(),HeaderText=HourNames.Rows[i].ItemArray[2].ToString() });
                }
    
    
                for (int classCounter = 0; classCounter < ClassNames.Rows.Count; classCounter++)
                {
                    this.dataGridViewX1.Rows.Add(new object[]{ClassNames.Rows[classCounter].ItemArray[2].ToString()});
                    this.dataGridViewX1.Rows[classCounter].Cells[0].Tag = ClassNames.Rows[classCounter].ItemArray[0].ToString();
                }
                
    
                //------------------------ fill combobox ------------------------------
                
                DataTable termValues = CrudClass.SelectAll("SELECT * FROM terms","terms");
                DataTable dayValues = CrudClass.SelectAll("SELECT * FROM days", "days");
    
                this.comboBox1.DataSource = termValues;
                this.comboBox1.DisplayMember = "term_name";
                this.comboBox1.ValueMember = "term_id";
    
    
                this.comboBox2.DataSource = dayValues;
                this.comboBox2.DisplayMember = "day_name";
                this.comboBox2.ValueMember = "day_id";
                
                
            }
    
            private void dataGridViewX1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                
            }
    
            private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
    
                if (comboBox1.Items.Count>0 && comboBox2.Items.Count>0 && dataGridViewX1.Columns.Count>1 && dataGridViewX1.Rows.Count>0 
                    
                    && e.ColumnIndex >0 && e.RowIndex>=0 )
                {
                    add_timetable frm_add_timetable = new add_timetable();
                    frm_add_timetable.term_id = this.comboBox1.SelectedValue.ToString();
                    frm_add_timetable.day_id = this.comboBox2.SelectedValue.ToString();
                    frm_add_timetable.hour_id = this.dataGridViewX1.Columns[e.ColumnIndex].Name;
                    frm_add_timetable.class_id = this.dataGridViewX1.Rows[e.RowIndex].Cells[0].Tag.ToString();
                    frm_add_timetable.ShowDialog();
                }
    
    
                
                
    
            }
    
            private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                FillDataGrid();
            }
    
            private void timetable_Activated(object sender, EventArgs e)
            {
                FillDataGrid();
            }
        }
    }
