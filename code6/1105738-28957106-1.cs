            private void getValues(string custOrder)
            {
                double num;
                if (custOrder.Split('$').Count() > 1)
                {
                    order.item = custOrder.Split('$')[0];
                   if (double.TryParse(custOrder.Split('$')[1], out num))
                    { 
                        order.price = Convert.ToDouble(custOrder.Split('$')[1]);                     
                        listOutput.Items.Add("Price:" + order.price);
                        finalBill += "Ordered Item:" + order.item + "\nPrice:" + order.price.ToString("C2") + "\n";
                        updateBill();
                    }
                }
             }
