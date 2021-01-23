    //In your xaml
    <toolkit:ListPicker Height="60"  Name="Dropdown" ExpansionMode="FullScreenOnly"  Width="210" >
                    <toolkit:ListPicker.ItemTemplate>
                        <DataTemplate>
                            <TextBlock  Text="{Binding}"/>
                        </DataTemplate>
                    </toolkit:ListPicker.ItemTemplate>
                    <toolkit:ListPicker.FullModeItemTemplate>
                        <DataTemplate>
                            <TextBlock   Text="{Binding}"  Margin="2,10,0,0" FontSize="31"/>
                        </DataTemplate>
                    </toolkit:ListPicker.FullModeItemTemplate>
                </toolkit:ListPicker>
 
     protected override void OnNavigatedTo(NavigationEventArgs e)
       {
        if (e.NavigationMode != NavigationMode.Back)
          {
           //Code behind On page load event.
           List<string> dropDownList = new List<string>();
           dropDownList.Add("item1");
           dropDownList.Add("item2");
           dropDownList.Add("item3");
           dropDownList.Add("item4");
           dropDownList.Add("item5");
           dropDownList.Add("item6");
           dropDownList.Add("item7");
           dropDownList.Add("item8");
        
        Dropdown.ItemsSource = dropDownList;
       }
     }
