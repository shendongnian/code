        <ComboBox Name="avilibity"
                  HorizontalAlignment="Stretch"
                  VerticalAlignment="Stretch"
                  Grid.Column="1">
            
            <ComboBoxItem>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="25"/>
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
                    <Image Grid.Column="0" Source="App.ico" ></Image>
                    <TextBlock FontSize="14" Grid.Column="1" >Available</TextBlock>
                </Grid>
            </ComboBoxItem>
            
            <ComboBoxItem>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="25"/>
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
                    <Image Grid.Column="0" Source="App.ico" ></Image>
                    <TextBlock FontSize="14" Grid.Column="1" >Offline</TextBlock>
                </Grid>
            </ComboBoxItem>
            <ComboBoxItem>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="25"/>
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
                    <Image Grid.Column="0" Source="App.ico" ></Image>
                    <TextBlock FontSize="14" Grid.Column="1" >Away</TextBlock>
                </Grid>
            </ComboBoxItem>
        </ComboBox>
