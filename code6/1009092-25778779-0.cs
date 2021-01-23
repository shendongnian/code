     <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition />
                <ColumnDefinition />
            </Grid.ColumnDefinitions>
    
            <Grid Grid.Column="0">
                <Grid.RowDefinitions>
                    <RowDefinition Height="Auto" />
                    <RowDefinition />
                </Grid.RowDefinitions>
               
                <Expander HorizontalAlignment="Right"
                      VerticalAlignment="Top" ExpandDirection="Down" Width="150">
                    <Expander.Header>
                        <StackPanel Grid.Row="1"  Margin="10,5,0,0">
                            <RadioButton Content="Choice One"/>
                            <RadioButton Content="Choice Two"/>
                            <RadioButton Content="Choice Three"/>
                        </StackPanel>
                    </Expander.Header>
                    <TextBlock TextWrapping="Wrap" Background="AntiqueWhite">
                    This is the standard expander
                    behavior.  The expander opens
                    and the controls below it 
                    move down.
                    </TextBlock>
                </Expander>
    
            </Grid>
        </Grid>
