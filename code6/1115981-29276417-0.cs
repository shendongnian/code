    private void Button_Click(object sender, RoutedEventArgs e)
        {
    		using(rDatabaseEntities rde = new rDatabaseEntities())
    		{
    			rde.TransporterId = dataGridView.rows.count-1;
    			rde.SaveChanges();
    		}
    	}
