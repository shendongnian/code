    <TabControl>
        <TabItem Name="TabItem1" Header="TabItem1">
            <TextBox Text="tab is NOT focused" >
               <TextBox.Style>
                  <Style TargetType="{x:Type TextBox}">
                     <Style.Triggers>
                        <DataTrigger Binding="{Binding IsFocused, ElementName=TabItem1}" Value=True>
                           <Setter Property="Text" Value="tab is focused" />
                        </DataTrigger>
                     </Style.Triggers>
                  </Style>
               </TextBox.Style>
             </TextBox>
        </TabItem>
    </TabControl>
