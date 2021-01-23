    protected void FormView1_ItemInserting event has no Exception
    
    You have to use Inserted event handler, not Inserting event !!!
    
    Like this : 
    
    protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
    	if (e.Exception != null)
    	{
    		Label1.Text = "Error : " + e.Exception.Message;
    
    		e.ExceptionHandled = true;
    	}
         else
         {
            Label1.Text = "Inserted Successfully";
         }
    }
