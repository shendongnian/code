    protected void btn_Click(object sender, EventArgs e){
        try {            
           Product product = new Product(Convert.ToInt32(txt.Text));
        }
        catch (FormatException e)
        {
            throw new CustomException();
        }
