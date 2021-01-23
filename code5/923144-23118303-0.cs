    public TextBox CheckBox() {   
            var itemBoxArray = new TextBox[] { itemBox0, itemBox1, itemBox2, itemBox3, itemBox4, itemBox5, itemBox6, itemBox7,
                itemBox8, itemBox9,itemBox10,itemBox11,itemBox12,itemBox13,itemBox14,itemBox15,};
            return itemBoxArray.First(m => string.IsNullOrEmpty(m.Text));//or  FirstOrDefault
        }
