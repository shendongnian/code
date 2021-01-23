    public partial class TableForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int rowNum = 4;
            int cellNum = 10;
            int idcell = 1;
            int idrow = 1;
            for (int i = 0; i < rowNum; i++)
            {
                TableRow aNewRow = new TableRow();
                for (int j = 0; j < cellNum; j++)
                {
                    TableCell aNewCell = new TableCell();
                    Button aNewButton = new Button();
                    //aNewButton.Click += new System.EventHandler(this.Button_Click_First_Row);
                    aNewButton.ID = "R" + idrow + "B" + idcell;
                    aNewButton.Text = "Boka";
                    aNewButton.CssClass = "dynamicbuttons";
                    aNewCell.Controls.Add(aNewButton);
                    aNewRow.Cells.Add(aNewCell);
                    idcell++;
                }
                Table1.Rows.Add(aNewRow);
                idrow++;
            }
        }
    }
