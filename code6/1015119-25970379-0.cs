    int greenRows = 0;
    for (int i = IndexNumberOfGridReceiver; i < WhatsAppCheckTotal - 1; i++)
    {
        if (form1.gridReceiver.Rows[i].Cells[1].Value.ToString().Equals(csvRow))
        {
            greenRows++;
            form1.gridReceiver.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
        }
        else
        {
            form1.gridReceiver.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
        }
        IndexNumberOfGridReceiver = i;
    }
