    WpfApplication2.OrderDetails.OrderDetailsHeader header = new OrderDetails.OrderDetailsHeader(){
                    Address = "tata",
                    ExternalDocNo = "toto",
                    Lines = new ObservableCollection<OrderDetails.OrderDetailsLine>()
                };
                header.Lines.Add(new OrderDetails.OrderDetailsLine()
                {
                    ItemDescription = "toto",
                    ItemNo = "titi",
                    Price = 100,
                    Quantity = 2
                });
    
                this.ExternalDoc.DataContext = header;
                this.ItemsListView.ItemsSource = header.Lines;
