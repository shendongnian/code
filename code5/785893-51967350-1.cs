    <ColumnDefinition>
      <ColumnDefinition.Style>
        <Style TargetType="ColumnDefinition">
          <Setter Property="Width" Value="*" />
            <Style.Triggers>
              <DataTrigger Binding="{Binding IsColumnVisible}" Value="False">
                <Setter Property="Width" Value="0" />
              </DataTrigger>
            </Style.Triggers>
        </Style>
      </ColumnDefinition.Style>
    </ColumnDefinition>
