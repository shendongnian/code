    <ScrollViewer VerticalScrollBarVisibility="Auto">
            <ScrollViewer.Resources>
                <BooleanToVisibilityConverter x:Key="BoolConverter"/>
            </ScrollViewer.Resources>
            <ItemsControl x:Name="icFields">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <Grid x:Name="FieldTypes" Margin="10,10,10,10">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="75"></ColumnDefinition>
                                <ColumnDefinition Width="*"></ColumnDefinition>
                            </Grid.ColumnDefinitions>
                            <Label Content="{Binding FieldName}" />
                            <TextBox Grid.Column="1" Visibility="{Binding ShowText, Converter={StaticResource BoolConverter}}"/>
                            <CheckBox Grid.Column="1" Visibility="{Binding ShowCheckBox, Converter={StaticResource BoolConverter}}" />
                        </Grid>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
        </ScrollViewer>
    public class Fields
    {
        public string FieldName
        {
            get;
            set;
        }
        public string FieldValue
        {
            get;
            set;
        }
        public bool ShowText
        {
            get;
            set;
        }
        public bool ShowCheckBox
        {
            get;
            set;
        }
        private int fieldType;
        public int FieldType
        {
            get
            {
                return fieldType;
            }
            set
            {
                fieldType = value;
                ShowText = false;
                ShowCheckBox = false;
                switch (fieldType)
                {
                    case 0:
                        ShowText = true;
                        break;
                    case 1:
                        ShowCheckBox = true;
                        break;
                }
            }
        }
    }
