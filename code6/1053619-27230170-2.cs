    private Form1 _myFirstForm;
    public Form2(Form1 myForm)
    {
      _myFirstForm = myForm;
    }
    private void tableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      System.Data.DataRowView SelectedRowView;
      Database1DataSet.TableRow SelectedRow;
      SelectedRowView = (System.Data.DataRowView)tableBindingSource.Current;
      SelectedRow = (Database1DataSet.TableRow)SelectedRowView.Row;
      _myFirstForm.NomeCliente = SelectedRow.nome_cliente;
    }
