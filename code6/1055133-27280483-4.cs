    private void btnProduct_Click(object sender, EventArgs e)
    {
        // A "using" block will take care of disposing of your Form
        //  when you're finished using it.
        using (var productSelect = new product_list())
        {
            productSelect.ShowDialog();
            var itemsFromSecondForm = productSelect.ProductList;
            // do something with itemsFromSecondForm
        }
    }
