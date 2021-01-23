    <TextBox x:Name="SomeText">
      <interactivity:Interaction.Triggers>
        <interactivity:EventTrigger EventName="TextChanged">
          <interactivity:InvokeCommandAction Command="{Binding SomeCommand, Mode=OneWay}"/>
        </interactivity:EventTrigger>
      </interactivity:Interaction.Triggers>        	
    </TextBox>
