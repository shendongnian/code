    catch(Exception e)
    {
       MessageBox.Show("Error: " + e.Message, "Exception Thrown", MessageBoxButtons.OK, MessageBoxIcon.Error);
       OtherMethod(); //Or something like this
    }
