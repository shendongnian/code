            <TextBox Text="{Binding SearchText, Mode=TwoWay}">
                <i:Interaction.Triggers>
                    <i:EventTrigger EventName="TextChanged">
                        <i:InvokeCommandAction Command="{Binding MyCommand}" />
                    </i:EventTrigger>
                </i:Interaction.Triggers>
            </TextBox>
