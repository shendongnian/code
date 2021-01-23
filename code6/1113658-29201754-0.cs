    protected SqlHelper(DataGridView dgv)
    {
        _dgv = dgv;
        _dgv.DataError += _dgv_DataError;
    }
    
    void _dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        if (e.Exception != null)
        {
            MessageBox.Show(string.Format("Incorrect data: {0}", e.Exception.Message) );
            e.Cancel = false;
            // handle the exception
        }
    }
