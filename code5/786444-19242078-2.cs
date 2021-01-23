    private void button1_Click(object sender, EventArgs e)
    {
        B childForm = new B();
    
        //Find the textbox control in the child form
        Control[] controls = childForm.Controls.Find("textBox", true);
    
        if (null != controls[0])
        {
            //Bind the method in the parent form to child form text control's TextChanged event
            controls[0].TextChanged += new System.EventHandler(SetChildFromValueToParent);
        }
    
        childForm.ShowDialog();
    }
