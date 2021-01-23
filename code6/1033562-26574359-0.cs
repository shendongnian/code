     <ComboBox ItemsSource="{Binding MyDataContext.SomeList}" 
               Template="{DynamicResource ComboBoxControlTemplate}"
              SelectedValue="{Binding MyDataContext.SelectedEntry}"
              Grid.Row="1">
       <ComboBox.Style>
           <Style TargetType="ComboBox">
              <Style.Triggers>
                 <DataTrigger Binding="{Binding Path=BlinkDepProp, 
                                                RelativeSource={RelativeSource 
                                         AncestorType={x:Type loc:DevicesRepositoryEditorUserControl}}}" Value="True">
                     <Setter Property="Background" Value="{Binding Background, ElementName=tb}"/>
                 </DataTrigger>
              </Style.Triggers>
           </Style>
       </ComboBox.Style>
     </ComboBox>
