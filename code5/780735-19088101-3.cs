    private List<myclass> productDetails = new List<myclass>();
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
            if (e.CommandName == "datacommand")
            {
                int productId = Convert.ToInt32(e.CommandArgument.ToString());
                if (productDetails != null && productDetails.Count() > 0)
                {
                    bool isexist = productDetails.Any(p => p.product_id == productId);
                    if (isexist)
                    {
                        myclass product = productDetails.Where(p => p.product_id == productId).FirstOrDefault();
                        productDetails.Add(new myclass
                        {
                            product_id = product.product_id,
                            price = product.price,
                            qty = product.qty + 1,
                            total = Convert.ToDouble((product.price) * (product.qty + 1))
                        });
                    }
                    else
                    {
                        double productPrice = Convert.ToDouble(GridView1.Rows[0].Cells[3].Text);
                        double productTotal = productPrice * 1;
                        productDetails.Add(new myclass
                        {
                            product_id = Convert.ToInt32(e.CommandArgument.ToString()),
                            price = productPrice,
                            qty = 1,
                            total = productTotal
                        });
                    }
                }
            }
    }
