     public class test
        {
        public string Id{get;set;}
        public string Name{get;set;}
        
        public test(string id, string name)
        
        {
          Id=id;
          Name=name;
        }
         public test()
        
        {
        }
        
        than add your take one generc like 
        
        List<Test> lst=new List<test>();
        
        private void Listado2(object sender, ListadoCompletedEventArgs e)
            {
              lst.add(new test(id,name));
               listB.itemsource=lst;
        
            }
    
    <ListBox x:Name="listB">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition />
                            <ColumnDefinition />
                        </Grid.ColumnDefinitions>
    
        <TextBlock Text="{Binding Id}" Grid.Column="0" />
        <TextBlock Text="{Binding Name}" Grid.Column="1" />
    
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
