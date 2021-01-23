    class NameValueHolder
    {
       public string Name{get;set;}
       public int Value{get;set;}
       public NameValueHolder(){}//so you can use it in linq
       public NameValueHolder(string name, int value)
       {
          this.Name=name;
          this.Value=value;
       }
    }
    
    BindingList<NameValueHolder> list = new BindingList<NameValueHolder>();
    list.Add(new NameValueHolder("object 1", 1);
    list.Add(new NameValueHolder("object 2", 2);
    list.Add(new NameValueHolder("object 3", 3);
    
    mycomboBox.DataSource = new BindingSource(list, null);
    mycomboBox.DisplayMember = "Name";
    mycomboBox.ValueMember = "Value";
        
    if(mycomboBox.SelectedIndex!=-1)
       NameValueHolder currentlySelected = (NameValueHolder)mycomboBox.SelectedValue;
