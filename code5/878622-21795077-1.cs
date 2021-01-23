    if (type_combobox.SelectedIndex >= 0 && unit_combobox.SelectedItem >= 0)
    {
        pro_business sb = new pro_business();  //business layer class
        string name = up_name.Text;  
        sb.Ppro_name = name;
        string type= type_combobox.Text; 
        string unit = unit_combobox.Text;
        sb.Ppro_unit = unit;         
        string message1 = sb.UpdateProductDetails(name, type, unit);
    }
