    Class A
    {
    
       public void addToListViewMedia()
        {    
            listViewMedia.Items.Add(new ListViewItem("datafromotherfile"));
        }
    
    }
    
    Class B
    {
    
         private void ausführenButton_Click(object sender, EventArgs e)
         { 
            A obj=new A();  //create instance variable.
            obj.addToListViewMedia();//access methods of A using instance variable
         } 
    
    }
