    private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var context = new WpfApplication4.Database1Entities();
            var table = context.Set<YourTable>();
            table.Add(new YourTable { Id = id, Name = "John Doe" });
            context.SaveChanges();
        }
