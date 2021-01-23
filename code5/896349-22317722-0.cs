    void Send_Mail()
        {
            try
            {
                 int rowCount = 0; 
                string Pass, FromEmailid, HostAdd;
    
                foreach (GridViewRow gr in DataGridView.Rows)
                {
                    rowCount++;
                    if(rowCount == 10)
                      {
                         SendMail1();
                      }
                    else if (rowCount == 20)
                      {
                          SendMail2();
                       }
    
                }
            }
        }
