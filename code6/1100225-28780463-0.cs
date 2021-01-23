    <ListView SelectionMode="Single" MinHeight="400" ItemsSource="{Binding Partners}" 
              SelectedItem="{Binding SelectedPartner, Mode=TwoWay}">
        <ListView.Style>
            <Style TargetType="ListView">
                <Setter Property="IsEnabled" Value="False"/>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding SelectedPartner}" Value="{x:Null}">
                        <Setter Property="IsEnabled" Value="True"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ListView.Style>
        <ListView.View>
           ...
        </ListView.View>
    </ListView>
