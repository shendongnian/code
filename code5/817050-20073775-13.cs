    private void CellClicked(object sender, MouseButtonEventArgs e)
    {
        String cellContent = ((TextBlock)sender).Text;
        xamlAllocateAudit window = new xamlAllocateAudit
        {
            DataContext = cellContent
        }
        window.Show();
    }
