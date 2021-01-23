     <Style x:Key="RButton" TargetType="Button">
         <Setter Property="Template">
             <Setter.Value>
                 <ControlTemplate TargetType="Button">
                     <Grid>
                         <Ellipse x:Name="Elipse1" Fill="Red" ></Ellipse>
                         <ContentPresenter  HorizontalAlignment="Center" VerticalAlignment="Center"></ContentPresenter>
                     </Grid>
                     <ControlTemplate.Triggers>
                         <Trigger Property="IsMouseOver" Value="True">
                             <Setter Property="Fill" Value = "Orange" TargetName="Elipse1" ></Setter>
                         </Trigger>
                     </ControlTemplate.Triggers>
                 </ControlTemplate>
             </Setter.Value>
         </Setter>
     </Style>
