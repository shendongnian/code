    private void button3_Click(object sender, EventArgs e)
    {
        DialogResult dialres =;
    
        if ( MessageBox.Show("Sunteti sigur ca vreti sa va deconectati?",
          "Atentie!", MessageBoxButtons.YesNo) == DialogResult.No) return;
        //when it ain't 'No' it is definitely 'Yes'  
        try
        {
           _conn.Close();
           _conn = null;
         }
           catch (Exception ex)
           {
              MessageBox.Show(ex.Message);
              return;
           }
    
           button1.Enabled = true;
           stopbut();
        }
        else if (dialres == DialogResult.No) 
        { 
           return; 
        }
    }
