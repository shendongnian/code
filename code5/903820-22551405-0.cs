         private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            Client clients = new Client();
            clients = (Client)gridControl1.MainView.GetRow(e.RowHandle);
            MessageBox.Show(clients.Email);
        }
