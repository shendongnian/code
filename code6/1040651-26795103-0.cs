    int counter = customer_Ship_ContactsDataGridView.Rows.count;
    for(int i = 0; i< counter; i++){
    if(i == counter){
    //this is where your LAST LINE code goes
      row.DefaultCellStyle.BackColor = Color.Yellow;
    } else {
    //this is your normal code NOT LAST LINE
      row.DefaultCellStyle.BackColor = Color.Red;
    }
    }
         
