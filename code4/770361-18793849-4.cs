    private void generate_Click(object sender, RoutedEventArgs e)
    {
    	int i = 0;
    	string[] name = { "Sentra", "IS", "Camry" };
    	string[] make = { "Nissan", "Lexus", "Toyota" };
    	string[] year = { "2003", "2011", "2013" };
    
    	foreach (string s in name)
    	{
    		Car car = new Car();
    		car.Name = name[i];
    		car.Make = make[i];
    		car.Year = year[i];
    		
    		if (year[i] == "2013")
    		{
    			car.YearProperty = new CarProperty();
    			car.YearProperty.Background = new SolidColorBrush(Colors.Blue);
    			car.YearProperty.Foreground = new SolidColorBrush(Colors.Yellow);
    			car.YearProperty.FontWeight = FontWeights.Bold;
    		}
    
    		carList.Items.Add(car);
    
    		i++;
    	}
    }
