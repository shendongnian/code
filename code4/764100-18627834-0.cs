    public class Form1
        {
            private Form2 form2;
            public Form1()
            {
                this.form2 = new Form1();
                this.form2.Show();
            }
        }
        public class Form2
        {
            public Form2()
            {
            }
            public void AddItemToListView(string itemName)
            {
                // Check if itemName is valid and add it to your listView
            }
            public void RemoveItemFromListViewAt(int position)
            {
                // Check if the position is valid and remove the item at the position
            }
        }          
