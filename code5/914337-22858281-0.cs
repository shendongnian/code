    //In your xaml
    <toolkit:ListPicker Height="60"  Name="Dropdown" ItemCountThreshold="1"  Width="210" >
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
 
    //Code behind On page load event.
    public List<string> dropDownList = new  public List<string>();
       dropDownList.Add("item1");
       dropDownList.Add("item2");
       dropDownList.Add("item3");
       dropDownList.Add("item4");
       dropDownList.Add("item5");
       dropDownList.Add("item6");
       dropDownList.Add("item7");
       dropDownList.Add("item8");
    
    Dropdown.ItemsSource = dropDownList;
