    <ContentControl Content="{Binding Value}" Grid.Column="2">
        <ContentControl.Resources>
            <DataTemplate DataType="{x:Type System:String}">
                <TextBox Text="{Binding RelativeSource={RelativeSource AncestorType=ContentControl}, Path=DataContext.Value}" BorderThickness="0" />
            </DataTemplate>
            <DataTemplate DataType="{x:Type System:Int32}">
                <TextBox Text="{Binding RelativeSource={RelativeSource AncestorType=ContentControl}, Path=DataContext.Value}"
                         TextAlignment="Right"
                         BorderThickness="0"/>
            </DataTemplate>
            <DataTemplate DataType="{x:Type System:Double}">
                <TextBox Text="{Binding RelativeSource={RelativeSource AncestorType=ContentControl}, Path=DataContext.Value}"
                         TextAlignment="Right"
                         BorderThickness="0"/>
            </DataTemplate>
            <DataTemplate DataType="{x:Type System:Boolean}">
                <CheckBox IsChecked="{Binding RelativeSource={RelativeSource AncestorType=ContentControl}, Path=DataContext.Value}"
                              HorizontalAlignment="Center"/>
            </DataTemplate>
        </ContentControl.Resources>
    </ContentControl>
