    <TextBox Grid.Row="1" Height="23" Width="132" Margin="451,30,0,0" 
             Text="{Binding Path=PositionName}">
        <TextBox.Style>
            <Style TargetType="TextBox" BasedOn="{StaticResource TextBoxStyleValue}">
               <Setter Property="Visibility" Value="Collapsed"/>
               <Style.Triggers>
                  <DataTrigger Binding="{Binding IsDepProp1,
                                   RelativeSource={RelativeSource FindAncestor,
                                           AncestorType={x:Type UserControl}}}"
                                Value="True">
                      <Setter Property="Visibility" Value="Visible"/>
                  </DataTrigger>
                  <DataTrigger Binding="{Binding IsDepProp2,
                                  RelativeSource={RelativeSource FindAncestor,
                                          AncestorType={x:Type UserControl}}}"
                               Value="True">
                      <Setter Property="Visibility" Value="Visible"/>
                   </DataTrigger>
                </Style.Triggers>
             </Style>
          </TextBox.Style>
    </TextBox>
