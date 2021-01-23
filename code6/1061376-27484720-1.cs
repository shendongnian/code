    <DataGridTextColumn Header="Name" Width="300" Binding="{Binding Name}"/>
    <DataGridTextColumn Header="Price" Width="100" Binding="{Binding Price}"/>
    while((line = sr.ReadLine()) != null)
                    {
                        var mass = line.Split(' ');
                        var newProduct = new Product
                        {
                            Name = mass[0].ToString(),
                            Price = Convert.ToInt32(mass[1])
                        };
                        dataGrid1.Items.Add(newProduct);
                    }
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
