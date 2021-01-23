        //Omitted for brevity
         private SyncListBox listBox1;
         private SyncListBox listBox2;
        
        //Omitted for brevity
        
         this.listBox1 = new WindowsFormsApplication1.SyncListBox();
         this.listBox2 = new WindowsFormsApplication1.SyncListBox();
        
        //Omitted for brevity
        listBox1.OnVerticalScroll += listBox1_OnVerticalScroll;
        listBox2.OnVerticalScroll += listBox2_OnVerticalScroll;
    
        //Event handlers
        void listBox2_OnVerticalScroll(object sender, ScrollEventArgs e)
        {
           listBox1.TopIndex = listBox2.TopIndex;
        }
    
        void listBox1_OnVerticalScroll(object sender, ScrollEventArgs e)
        {
           listBox2.TopIndex = listBox1.TopIndex;
        }
