    public class MainVm : VMBase
        {
            public ObservableCollection<TabVM> Items { get; set; }
            public VMBase SelectedItem {get;set;} 
            public MainVm()
            {
                Items = new ObservableCollection<TabVM>()
                {
                    new TabVM(){Header="A",Content = new SomeVm()},
                    new TabVM(){Header="B",Content = new SomeVm()},
                    new TabVM(){Header="C",Content = new SomeVm()},
                    new TabVM(){Header="D",Content = new OtherVm()}
                };
            }
        }
    
        public class TabVM : VMBase
        {
            public string Header { get; set; }
            public VMBase Content { get; set; }
        }
    
        public class SomeVm : VMBase{}
        public class OtherVm : VMBase{}
        public class VMBase { }
    <TabControl ItemsSource="{Binding Items}" SelectedItem="{Binding SelectedItem}">
            <TabControl.Resources>
                <DataTemplate DataType="{x:Type local:SomeVm}">
                    <TextBlock>SomeVm Template</TextBlock>
                </DataTemplate>
                <DataTemplate DataType="{x:Type local:OtherVm}">
                    <TextBlock>OtherVm Template</TextBlock>
                </DataTemplate>
            </TabControl.Resources>
            <TabControl.ItemTemplate>
                <DataTemplate>
                        <TextBlock Text="{Binding Header}"></TextBlock>
                </DataTemplate>
            </TabControl.ItemTemplate>
            <TabControl.ContentTemplate>
                <DataTemplate>
                    <ContentControl Content="{Binding Content}"></ContentControl>
                </DataTemplate>
            </TabControl.ContentTemplate>
        </TabControl>
