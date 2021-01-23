    (s, args) =>
            {
                popup.IsOpen = false;
                //pick input from the popup's textbox.
                qty = control.tbx.Text;
                if (qty == null||qty=="") { qty = "0"; }
                //send clicked item to cart for addition
                TextBlock clicked = ((TextBlock)sender);
                string temp = clicked.Text;
                Cart.cart_new.additem(temp, qty);
                Debug.WriteLine("called method with "+sender.ToString());
                tb_pamount_lunch.Text = Convert.ToString(Cart.cart_new.get_num_of_items());
                //tb_pamount_lunch.Text = tapped.ToString();
                MessageBox.Show(temp);
                //update the dinner stackpanel to display the selected items
                sp_dinner.Children.Clear();
                List<item> display = Cart.cart_new.getitems();
                for (int i = 0; i < display.Count; i++)
                {
                    TextBlock tb1 = new TextBlock();
                    tb1.FontSize = 36;
                    tb1.Text = display[i].getname().ToString();
                    sp_dinner.Children.Add(tb1);
                }
            };
        control.btnCancel.Click += (s, args) =>
            {
                //close popup when cancel is clicked
                popup.IsOpen = false;
            };
