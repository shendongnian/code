    void ButtonFindCustomer_Click(object sender, EventArgs e)
    {
        m_order.Customer = Customer.Find(TextBoxFirst.Text, TextBoxLast.Text, TextBoxCustomerID.Text);
    }
    void ButtonAddProduct_Click(object sender, Event args)
    {
        m_order.AddArticle(Product.Find(TextBoxArticleNumber.Text), NumericUpDownArticleAmount.Value);
    }
    void ButtonSubmit_Click(object sender, EventArgs e)
    {
        m_order.Place();
    }
