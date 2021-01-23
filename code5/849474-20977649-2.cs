    <CheckBox>
       <CheckBox.Style>
          <Style TargetType="CheckBox">
             <Setter Property="Visibility" Value="Collapsed"/>
             <Style.Triggers>
                <MultiDataTrigger>
                   <MultiDataTrigger.Conditions>
                      <Condition Binding="{Binding IsEnable}" Value="True"/>
                      <Condition Binding="{Binding ElementName=Allowed,
                                               Path=IsChecked}" Value="True"/>
                   </MultiDataTrigger.Conditions>
                   <Setter Property="Visibility" Value="Visible"/>
                </MultiDataTrigger>
             </Style.Triggers>
          </Style>
        </CheckBox.Style>
     </CheckBox>
