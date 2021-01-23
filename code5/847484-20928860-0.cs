    public Class Main
     {
    	int tester;
    	List<TextBox> listScreens;
        public void button1_Click(object sender, EventArgs e)
        {
    		....
    		Lists lists = new Lists();
            lists.MakeLabelList(tester);
    		//don't create new list, use global variable difined above
            listScreens = lists.MakeScreenList(tester);
    
            int screenX = 150;
    		....
    	}
    	
    	private void PrintSubmit_Click(object sender, EventArgs e)
        {
    		foreach(TextBox screens in listScreens){
    			MessageBox.Show(screens.Text);
           }
        }
    }
