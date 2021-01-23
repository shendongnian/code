            private void bagOrder_Load(object sender, System.EventArgs e)
            {
        
                Order newOrder = new Order();
                for (int i = 0; i < newOrder.menuBag.Length; i++)
                {
                    this.lstBxBagType.Items.Add
                        (newOrder.menuBag[i]);
                }
            
    
             }
