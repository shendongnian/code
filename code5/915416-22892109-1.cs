    Parameter searchBox_par = New Parameter();
    
    protedted void Button1_Click(object sender, System.EventArgse As) {
    
        Integer intCount;
        string searchTxt = SearchBox.Text;
        string[] arrText = Split(searchTxt);
    
        For(int intCount = 0; intCount < arrText.length; intCount++) {
    
            searchBox_par.Name = "IDTextBox1";
            searchBox_par.Type = TypeCode.String;
            searchBox_par.DefaultValue = arrText[intCount];
    
            SqlDataSource3.SelectParameters.Clear();
            SqlDataSource3.SelectParameters.Add(searchBox_par);
            GridView2.Visible = true;
        }
    }
