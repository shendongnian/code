    You are actually creating one extra column by this way.
    To fix this you need to create a style for customizing Column Header template and set Header Template. Something like below
            
     <Style TargetType="DataGridColumnHeader">
                    <Setter Property="Template">
                        <Setter.Value>
                        <ControlTemplate>
                            <Button Content="Ok"/>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
    
    <DataGrid AutGenerateColumns="true" ItemsSource={Binding xxx} etc...>
    
    </DataGrid>
