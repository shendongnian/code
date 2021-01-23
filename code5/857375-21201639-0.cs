     private void button1_Click(object sender, EventArgs e)
            {
                  
             
        string whereClause = String.Join(",", richTextBox1.Text.Split(new string[] { "\n" }, StringSplitOptions.None));
            
        
            MessageBox.Show(" IN ( " + whereClause + ")");
            
            }
