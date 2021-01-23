    BindingList<object> listData = new BindingList<object>();
    listBox1.DataSource = listData;
    public void ShowForm2(){
      ListBox list = new ListBox();
      list.DataSource = listData;
      Form f = new Form() { BindingContext = this.BindingContext };//Set BindingContext the same to synchronize tracking item in both listBoxes.
      list.Parent = f;
      f.Show();
    }
    //This is used to add new item to the source
    public void AddItem(object item){
       listData.Add(item);
    }
    //This is used to remove an item from the source
    public void RemoveItem(object item){
       listData.Remove(item);
    }
    //This is used to remove an item by index from the source
    public void RemoveItemAt(int index){
       listData.RemoveAt(index);
    }
