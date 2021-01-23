    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            public class CustomDataGridView : DataGridView
            {
                protected override bool ProcessDialogKey(Keys keyData)
                {
                    //if enter pressed
                    if (keyData == Keys.Enter)
                    {
                        //return if no selected cells
                        if (this.CurrentCell == null)
                            return true;
    
                        //if current column is first column
                        if (this.CurrentCell.ColumnIndex == 0)
                            //move on to third
                            changeCurrentColumn(2, this.CurrentCell.RowIndex);
    
                        //if current column is thrid column
                        else if (this.CurrentCell.ColumnIndex == 2)
                            //move on to fourth
                            changeCurrentColumn(3, this.CurrentCell.RowIndex);
    
                        //if we're in last column
                        else if (this.CurrentCell.ColumnIndex == this.Columns.Count - 1)
                            //go one row down and to the first column
                            changeCurrentColumn(0, this.CurrentCell.RowIndex + 1);
    
                        return true;
                    }
                    else
                    {
                        return base.ProcessDialogKey(keyData);
                    }
                }
                private void changeCurrentColumn(int columnToMoveTo, int currentRow)
                {
                    //move on to next column
                    this.CurrentCell = this.Rows[currentRow].Cells[columnToMoveTo];
                    //and start editing
                    this.BeginEdit(true);
                }
            }
        }
    }
