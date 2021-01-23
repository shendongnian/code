    List<Cart> sCart = new List<Cart>();
    BindingSource source = new BindingSource();
    private void frmForm_Load(object sender, EventArgs e)
    {
        source.DataSource = sCart;
        this.gvCart.DataSource = source;
    }
    private void btnAdd_Click(object sender, EventArgs e)
    {
        Cart cart = new Cart(ProductID);
        if (sCart.Contains(cart) == false)
        {
        	//cart.pID = Convert.ToInt32(productID);
        	cart.pName = txtProName.Text;
        	cart.pDesc = txtDesc.Text;
        	cart.pPrice = Convert.ToInt32(lblDisplayPrice.Text);
        	cart.pAmount = Convert.ToInt32(txtAmount.Text);
        	cart.pTotal = Convert.ToInt32(lblDisplayPrice.Text) * Convert.ToInt32(txtAmount.Text);
        	sCart.Add(cart);
        }
        else
        {
        	cart = sCart[sCart.IndexOf(cart)];
        	cart.pAmount = cart.pAmount + Convert.ToInt32(txtAmount.Text);
        	cart.pTotal = cart.pAmount * cart.pPrice;
        }
        
        source.CurrencyManager.Refresh();    
    }
