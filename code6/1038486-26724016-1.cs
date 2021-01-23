        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            IceCreamOrder order = new IceCreamOrder();
            order.Flavor = FlavorsList.SelectedValue;
            foreach (ListItem listItem in ToppingsList.Items)
            {
                if (listItem.Selected)
                    order.Toppings.Add(listItem.Value);
            }
            order.Serve = ServeList.SelectedValue;
            // add order to order list
        }
        public class IceCreamOrder
        {
            public string Flavor { get; set; }
            public List<string> Toppings { get; set; }
            public string Serve { get; set; }
            public IceCreamOrder()
            {
                Toppings = new List<string>();
            }
        }
