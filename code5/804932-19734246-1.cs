    <ListBox ItemsSource="{Binding Fruits}">
       <ListBox.Resources>
          <local:IsLastItemInContainerConverter
                 x:Key="IsLastItemInContainerConverter"/>
       </ListBox.Resources>
       <ListBox.ItemsPanel>
          <ItemsPanelTemplate>
             <WrapPanel/>
          </ItemsPanelTemplate>
       </ListBox.ItemsPanel>
       <ListBox.ItemTemplate>
          <DataTemplate>
             <TextBlock x:Name="textBlock"
                        Text="{Binding Name, StringFormat=' {0},'}" />
                <DataTemplate.Triggers>
                    <DataTrigger Binding="{Binding RelativeSource={RelativeSource 
                                                   Mode=FindAncestor, 
                                                   AncestorType=ListBoxItem},
                                                   Converter={StaticResource IsLastItemInContainerConverter}}" 
                                 Value="True">
                        <Setter Property="Text" TargetName="textBlock"
                                Value="{Binding Name, StringFormat=' {0}'}"/>
                     </DataTrigger>
                </DataTemplate.Triggers>
           </DataTemplate>
       </ListBox.ItemTemplate>
    </ListBox>
