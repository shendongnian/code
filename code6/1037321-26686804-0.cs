    <Grid>  
      <Grid.Resources>
         <Style TargetType="Control">
           <Setter Property="Template">
             <Setter.Value>
               <ControlTemplate>
                   <DataGrid>
                      <DataGrid.Columns>
                         <DataGridTextColumn Header="Name"></DataGridTextColumn>
                         <DataGridTextColumn Header="City"></DataGridTextColumn>
                      </DataGrid.Columns>
                   </DataGrid>
               </ControlTemplate>
             </Setter.Value>
           </Setter>
         </Style>
      </Grid.Resources>
      <Grid.RowDefinitions>
         <RowDefinition/>
         <RowDefinition/>
         <RowDefinition/>
      </Grid.RowDefinitions>
      <!-- use 3 controls instead of 3 DataGrids -->
      <Control></Control>
      <Control Grid.Row="1"></Control>
      <Control Grid.Row="2"></Control>
    </Grid>
