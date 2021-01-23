        public void CheckBox()
        {
            TextBox[] itemBoxArray = new TextBox[] { itemBox1, itemBox2, ........};
            for (int i = 0; i < itemBoxArray.Length; i++)
            {
                if (String.IsNullOrEmpty(itemBoxArray[i].Text))
                {
                    MessageBox.Show(" " + itemBoxArray[i].Name + " Is empty");
                }
                else
                {
                    MessageBox.Show("Item Box is full");
                }
            }
        }
