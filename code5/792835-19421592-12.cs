        private void submitButton_Click(object sender, EventArgs e)
        {
            List<SalesInformation> sales = new List<SalesInformation>();
            SalesInformation newSales = new SalesInformation();
            newSales.SerialNo = Convert.ToInt32(serailNoTextBox.Text);
            newSales.ProductName = productNameTextBox.Text;
            newSales.Price = Convert.ToDecimal(priceTextBox.Text);
            newSales.Quantity = Convert.ToInt32(quantityTextBox.Text);
            newSales.Total = Convert.ToDecimal(totalTextBox.Text);
            sales.Add(newSales);
            myGridView.DataSource = sales;
        }
