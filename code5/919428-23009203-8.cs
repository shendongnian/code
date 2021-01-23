     private void buttonLarge_Click(object sender, EventArgs e)
            {
                listView.View = View.LargeIcon;
                //Set ImageIndex of Item 0 you could see its Icon.
                listView.Items[0].ImageIndex= 0 ;
                //set ImageKey will change nothing 
                //listView.Items[0].ImageKey= "0" ; 
            }
