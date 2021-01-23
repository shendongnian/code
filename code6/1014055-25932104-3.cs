    protected void Page_Load(object sender, EventArgs e)
                {
                    if(table!=null)
                    if(table .Rows.Count>0)
                    {
                       Textbox1.Text=table.Row[0][0].ToString();//In this way you can fill controls again
    //And user need not to type data again!! 
                   
    
       }
                     }
 
