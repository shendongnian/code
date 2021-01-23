      MessageBox.Show("Dot Net Perls is awesome.");
    	    //
    	    // Dialog box with text and a title. [2]
    	    //
    	    MessageBox.Show("Dot Net Perls is awesome.",
    		"Important Message");
    	    //
    	    // Dialog box with two buttons: yes and no. [3]
    	    //
    	    DialogResult result1 = MessageBox.Show("Is Dot Net Perls awesome?",
    		"Important Question",
    		MessageBoxButtons.YesNo);
    	    //
    	    // Dialog box with question icon. [4]
    	    //
    	    DialogResult result2 = MessageBox.Show("Is Dot Net Perls awesome?",
    		"Important Query",
    		MessageBoxButtons.YesNoCancel,
    		MessageBoxIcon.Question);
    	    //
    	    // Dialog box with question icon and default button. [5]
    	    //
    	    DialogResult result3 = MessageBox.Show("Is Visual Basic awesome?",
    		"The Question",
    		MessageBoxButtons.YesNoCancel,
    		MessageBoxIcon.Question,
    		MessageBoxDefaultButton.Button2);
