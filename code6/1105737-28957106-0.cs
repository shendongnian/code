            private void getValues(string custOrder)
            {
                double num;
                if (custOrder.Split('$').Count() > 1)
                {
                    order.item = custOrder.Split('$')[0];
                    order.price = Convert.ToDouble(custOrder.Split('$')[1]); 
                    if (double.TryParse(order.price, out num))
                    {   
                        listOutput.Items.Add("Price:" + order.price);
                        finalBill += "Ordered Item:" + order.item + "\nPrice:" + order.price.ToString("C2") + "\n";
                        updateBill();
                    }
                }
             }
