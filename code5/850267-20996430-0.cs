    onLoad()
    {
    Thread t = new Thread(new ThreadStart(t_trigger));
                t.Start();
    }
    
    
    private void t_trigger()
    {
     table_insert(string d)
    }
    
    private delegate void delegate_table_insert(string d);
    
    private void table_insert(string d)
            {
                if (InvokeRequired)
                {
                    try
                    {
                        Invoke(new delegate_table_insert(table_insert), d);
                    }
    
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        // here run the code
                    }
    
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }
