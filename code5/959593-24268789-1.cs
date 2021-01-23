    private async void btnPrueba_Click(object sender, RoutedEventArgs e)
    {
    
    
    Dictionary<string,string> parametros = new Dictionary<string,string>();
    parametros.Add("login", "12345678R");
    parametros.Add("password", "123123");
    
    objPrueba = new prueba();
    
    string result = await objPrueba.doPost("http://prueba.es/login", parametros);
    
    // You can use the string to update the GUI if you want, because this code is running on the GUI thread
    
    }
