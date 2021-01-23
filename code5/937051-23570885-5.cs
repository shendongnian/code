    public decimal Amount{
        get{
            return Convert.ToDecimal(txtAmount.text);
        }
    }
    void btnInsert_Click(Object sender, EventArgs e){
        presenter.Insert();
    }
