    <TextBox Grid.Column="0"
        Text="{Binding Input, UpdateSourceTrigger=PropertyChanged}">
        <b:Interaction.Triggers>
            <b:EventTrigger EventName="LostFocus">
                <b:InvokeCommandAction  Command="{Binding LostFocusCommand}" CommandParameter="{Binding Input}"/>
            </b:EventTrigger>
         </b:Interaction.Triggers>
      </TextBox>
