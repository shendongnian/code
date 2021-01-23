    namespace myTest
    {
        class Common
        {
            private Form1 mainForm;
    
            public Common()
            {
    
            }
            public Common(Form1 mMainForm)
            {
                mainForm = mMainForm;
            }
    
            public void AddItemToListView()
            {
                if(mainForm == null)
                    throw new InvalidOperationException("Class instance intialized with wrong constructor!");
                ListViewItem item1 = new ListViewItem("1");
                item1.SubItems.Add("1");
                item1.SubItems.Add("2");
                item1.SubItems.Add("3");
                item1.SubItems.Add("4");
                item1.SubItems.Add("5");
                item1.SubItems.Add("6");
                item1.SubItems.Add("7");
                item1.SubItems.Add("8");
      
                mainForm.tempAddToList(item1);
            }
        }
    }
