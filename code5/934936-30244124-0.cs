    <Button.Style>
       <Style TargetType="Button">
           <Setter Property="IsEnabled" Value="True"/>
               <Style.Triggers>
                     <MultiDataTrigger>
                         <MultiDataTrigger.Conditions>
                                    <Condition Binding="{Binding Path=Text.Length, ElementName=activationKeyTextbox}" Value="0"/>
                         </MultiDataTrigger.Conditions>
                         <Setter Property="IsEnabled" Value="False"/>
                         </MultiDataTrigger>
                         <MultiDataTrigger>
                         <MultiDataTrigger.Conditions>
                                    <Condition Binding="{Binding Path=Text.Length, ElementName=serialDayStartbox}" Value="0"/>
                         </MultiDataTrigger.Conditions>
                         <Setter Property="IsEnabled" Value="False"/>
                         </MultiDataTrigger>
                         <MultiDataTrigger>
                         <MultiDataTrigger.Conditions>
                            <Condition Binding="{Binding Path=Text.Length, ElementName=serialNumdaysbox}" Value="0"/>
                     </MultiDataTrigger.Conditions>
                     <Setter Property="IsEnabled" Value="False"/>
                 </MultiDataTrigger>
            </Style.Triggers>
        </Style>
     </Button.Style>
