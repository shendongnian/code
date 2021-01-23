    //method
    public static bool TryParse(
        	string s,
	        out int result
    )
    //How to use:
    int number;
    bool res = Int32.TryParse(myTable.Rows[i].Cells["column1"].Value.ToString(), out number);
    
    //if parse was successfull
    if(res)
    {
      //export to Excel
    }
    else
    {
      //throw exception, value was not an int
    }
