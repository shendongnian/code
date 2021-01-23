    var articulos = new List<string>(); 
    foreach (DataGridViewRow row in dataGridView1.Rows) 
    { 
        articulos.Add(Convert.ToString(row.Cells["Articulos"].Value)); 
    }
    string combinedString = string.Join<string>(" ", articulos); //this will have all the articles separated by a " " like article1 artice2 article3 
