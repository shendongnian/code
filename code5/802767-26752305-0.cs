    string a;
                a = Interaction.InputBox("message", "title");
                if (a.Length > 0)
    	        {
                    comboBox2.Items.Add(a);
                    // ok
                }
                else
                {
                    // cancel
                }
