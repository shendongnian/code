    public bool IsSelected { get; set; } // Implement INotifyPropertyChanged interface here
    <Style TargetType="{x:Type telerik:RadNumericUpDown}">
        <Style.Triggers>
            <DataTrigger Binding="{Binding IsSelected}" Value="True">
                <Setter Property="Background" Value="LightGreen" />
            </DataTrigger>
        </Style.Triggers>
    </Style>
