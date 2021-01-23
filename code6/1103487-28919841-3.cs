    <Window x:Class="WpfApplication2.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:myNamespace ="clr-namespace:WpfApplication2"
            Title="MainWindow" Height="350" Width="525" >
        <Window.Resources>
            <DataTemplate DataType="myNamespace:OrderDetailsListItem" x:Key="itemTemplate">
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text="{Binding Name}" Margin="0,5,0,0"/>
                    <TextBlock Text="{Binding Price, StringFormat=Price: {0:}}"></TextBlock>
                </StackPanel>
            </DataTemplate>
        </Window.Resources>
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <StackPanel Grid.Column="0">
                <Button Content="{x:Static myNamespace:GlobalVariables._amstelProductName}" Click="amstelBeerButton_Click"/>
    
    
                <TextBlock Text="{Binding TotalPrice, StringFormat=Total: {0:c}}"/>
            </StackPanel>
    
            <ListView Grid.Column="1" ItemsSource="{Binding OrderItem}">
                <ListView.View>
                    <GridView>
                        <GridViewColumn DisplayMemberBinding="{Binding Path=Name}" Header="Name"/>
                        <GridViewColumn DisplayMemberBinding="{Binding Path=Price, StringFormat=c}" Header="Price"/>
                        <GridViewColumn DisplayMemberBinding="{Binding Path=Quantity, StringFormat=N0}" Header="Quantity"/>
                    </GridView>
                </ListView.View>
            </ListView>
        </Grid>
    </Window>
<!---->
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows;
    
    namespace WpfApplication2
    {
        /// <summary>
        ///     Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public static readonly DependencyProperty TotalPriceProperty = DependencyProperty.Register(
                "TotalPrice", typeof (decimal), typeof (MainWindow), new PropertyMetadata(default(decimal)));
    
            private readonly BindingList<OrderDetailsListItem> _orderItem;
    
            public MainWindow()
            {
                _orderItem = new BindingList<OrderDetailsListItem>();
                _orderItem.ListChanged += OrderItemListChanged;
                InitializeComponent();
                DataContext = this;
                GetBeerInfo();
            }
    
            public BindingList<OrderDetailsListItem> OrderItem
            {
                get { return _orderItem; }
            }
    
            public decimal TotalPrice
            {
                get { return (decimal) GetValue(TotalPriceProperty); }
                set { SetValue(TotalPriceProperty, value); }
            }
    
            private void GetBeerInfo()
            {
                OrderItem.Add(new OrderDetailsListItem
                {
                    Name = "Some other beer",
                    Price = 2m,
                    Quantity = 1
                });
            }
    
            private void OrderItemListChanged(object sender, ListChangedEventArgs e)
            {
                TotalPrice = _orderItem.Select(x => x.Price).Sum();
            }
    
            private void amstelBeerButton_Click(object sender, RoutedEventArgs e)
            {
                //This variable makes me suspicous, this probibly should be a property in the class. 
                var quantityItem = GlobalVariables.quantityChosen;
    
                if (quantityItem == 0)
                {
                    quantityItem = 1;
                }
    
                var item = OrderItem.FirstOrDefault(i => i.Name == GlobalVariables._amstelProductName);
    
                if (item == null)
                {
                    OrderItem.Add(new OrderDetailsListItem
                    {
                        Name = GlobalVariables._amstelProductName,
                        Quantity = quantityItem,
                        Price = GlobalVariables._amstelPrice
                    });
                }
                else if (item != null)
                {
                    item.Quantity = item.Quantity + quantityItem;
                    item.Price = item.Price*item.Quantity;
                }
                //The UpdatePrice function is nolonger needed now that it is a bound property.
            }
        }
    
        public class GlobalVariables
        {
            public static int quantityChosen = 0;
            public static string _amstelProductName = "Amstel Beer";
            public static decimal _amstelPrice = 5;
        }
    
        public class OrderDetailsListItem : INotifyPropertyChanged, IEquatable<OrderDetailsListItem>
        {
            private string _name;
            private decimal _price;
            private int _quantity;
    
            public string Name
            {
                get { return _name; }
                set
                {
                    if (value == _name) return;
                    _name = value;
                    OnPropertyChanged();
                }
            }
    
            public decimal Price
            {
                get { return _price; }
                set
                {
                    if (value == _price) return;
                    _price = value;
                    OnPropertyChanged();
                }
            }
    
            public int Quantity
            {
                get { return _quantity; }
                set
                {
                    if (value == _quantity) return;
                    _quantity = value;
                    OnPropertyChanged();
                }
            }
    
            public bool Equals(OrderDetailsListItem other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return string.Equals(_name, other._name);
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public override bool Equals(object obj)
            {
                return Equals(obj as OrderDetailsListItem);
            }
    
            public override int GetHashCode()
            {
                return (_name != null ? _name.GetHashCode() : 0);
            }
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
