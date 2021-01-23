    protected void Button1_Click(object sender, EventArgs e)
    {
       string s = DropDownList2.SelectedItem.Value; 
       Converter c = GetConverters().Find(x => x.name == s);
       //do whatever with the converter
    }
