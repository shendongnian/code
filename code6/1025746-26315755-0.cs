        //..
        // create the new page
        TabPage tpNew = new TabPage("new page..");
        // add it to the tab
        this.tabControl2.TabPages.Add(tpNew);
        // create one labe with text and location like label1
        Label lbl = new Label();
        lbl.Text = label1.Text;
        lbl.Location = label1.Location;
        // create a new textbox..
        TextBox tbx = new TextBox();
        tbx.Location = textBox1.Location;
        tpNew.Controls.Add(lbl);
        tpNew.Controls.Add(tbx); 
        // add code to the new textbox via lambda code:      
        tbx.TextChanged += ( (sender2, evArgs) =>
        {
            if (tbx.Text != "")
                this.tabControl2.SelectedTab.Text = tbx.Text;
            else
                this.tabControl2.SelectedTab.Text = "(no name)";
        } );
