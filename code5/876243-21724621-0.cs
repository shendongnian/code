         if ((string.IsNullOrEmpty(TbTcNo.Text) || string.IsNullOrWhiteSpace(TbTcNo.Text)))
            {
                warningcase = 1;
                TextLabelManagement(warningcase);                              
            }
            if ((string.IsNullOrEmpty(TbId.Text) || string.IsNullOrWhiteSpace(TbId.Text)))
            {
                warningcase = 2;
                TextLabelManagement(warningcase);               
            }
             if ((string.IsNullOrEmpty(TbName.Text) || string.IsNullOrWhiteSpace(TbName.Text)))
            {
                warningcase = 3;
                TextLabelManagement(warningcase);      
            }
