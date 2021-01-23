    int numberForButton;
    for (int i =0;i<100;i++)
    {
        Button but = new Button();
    	//usual place button fields
    	but.MouseDoubleClick += click_event;
    	but.Name = btn+numberForButton;
    	numberForButton++;
    }
    private void btnName_Click(object sender, click_event e)
    {
        //for button 97 chosen at random
        if(((Button)Sender).Name.SubString(2) == 97)
        {
            //code what you want button 97 to do
        }
    }
