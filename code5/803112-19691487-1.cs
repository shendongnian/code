    <GridViewColumn HeaderContainerStyle="{StaticResource SmokeStyleHeaders}" Header="W()" Width="30" >
        <GridViewColumn.CellTemplate>
            <DataTemplate>
                <CheckBox Foreground="White" Checked="CheckBox_Checked" IsChecked="{Binding WebsiteJob, Converter={StaticResource CheckboxIsCheckedValueConverter}}" Content="{Binding WebsiteJob, Converter={StaticResource WebsiteJobValueConverter}}" />
            </DataTemplate>
        </GridViewColumn.CellTemplate>
    </GridViewColumn>
