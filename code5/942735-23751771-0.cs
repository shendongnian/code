    private int global_variable_name;
    private void Button_Click(object sender, RoutedEventArgs e) 
    { 
        count++; 
        for (int i = 1; i <= count; i++) 
        { 
            var tb = new TextBox(); 
            mycanvas.Children.Add(tb);  
            tb.Name = "txtbox"+i; 
            tb.Width = 100;  
            Canvas.SetLeft(tb,50); 
            Canvas.SetTop(tb, i*20); 
            // You can set global_variable_name here, but it'll be 
            // silly to set it to `i`, since it's changing
            global_variable_name = 8;
        } 
    } 
    private void SomeOtherMethod() {
        // you can use global_variable_name here
        var sum = global_variable_name + 3;
    }
    
