    private void addEventhandler(Control Parent) {
    
        if (Parent.Controls.Count > 0) {
            //===>If the curren control is a container!
            foreach(Control iChild in Parent.Controls) {
                addEventhandler(iChild);//Call it self
            }
        } else {//Individual control
            //===>TODO: Add here all your events handler to Parent variable.
                
            Parent.Click += new EvenHandler(delegate(object sender,object e){
                                                MessageBox.Show("Hello");
                                                });
            
            //==>If you whant to filter by control type you can do this
            if(Parent is TextBox){
                ((TextBox)Parent).Text = "Hi! XD";
            }
        }
    }
