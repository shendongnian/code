     // private void button1_Click(object sender, EventArgs e)
           private void button1_Click(object sender, CommandEventArgs e)
            {             
             string sourceUrl = Convert.tostring(e.CommandName) 
             // Call function to grab data pass URL as parameter.
              GrabDate (sourceUrl ) ;
            
