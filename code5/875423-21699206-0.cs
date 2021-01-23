    private void OnButtonClicked(object sender, EventArgs e)
    {
       float f; 
    
       if(float.TryParse((sender as Button).CommandArgument, out f))
       {
         textBox.Font = new Font(textBox.Font.FontFamily, textBox.Font.Size + f);
       }
    }
