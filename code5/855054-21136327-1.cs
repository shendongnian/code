    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                lbBasket.Items.Add(new Basket("Name 1", (decimal) 1.00, 1));
                lbBasket.Items.Add(new Basket("Name 2", (decimal) 2.00, 2));
            }
    
            private void btnAdd_Click(object sender, EventArgs e)
            {
                var newItem = new Basket(txtName.Text, Convert.ToDecimal(txtPrice.Text), Convert.ToInt32(txtQuantity.Text));
    
                var existingItem =
                    lbBasket.Items.Cast<Basket>()
                        .FirstOrDefault(li => li.Name.Equals(newItem.Name, StringComparison.OrdinalIgnoreCase));
                // There is something there 
                if (existingItem != null)
                {
                    // You already have the best one
                    if (existingItem.Price > newItem.Price)
                    {
                        // Do nothing
                        return;
                    }
                    // Price is the same
                    if (existingItem.Price == newItem.Price)
                    {
                        lbBasket.Items.Remove(existingItem);
                        newItem.Quantity += existingItem.Quantity;
                        lbBasket.Items.Add(newItem);
                    }
                    // Remove the old item and add the new one
                    else if (existingItem.Price < newItem.Price)
                    {
                        lbBasket.Items.Remove(existingItem);
                        lbBasket.Items.Add(newItem);
                    }
                }
                else
                {
                    lbBasket.Items.Add(newItem);
                }
            }
        }
    
        public class Basket
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
    
            public Basket(string name, decimal price, int quantity)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
            }
    
            public override string ToString()
            {
                return Name + " £" + Price + " " + Quantity;
            }
        }
    }
