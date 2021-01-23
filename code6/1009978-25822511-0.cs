                    <Button Content="Btn1">
                        <i:Interaction.Triggers>
                            <i:EventTrigger EventName="Click">
                                <i:InvokeCommandAction Command="{Binding LoadSegmentCommand}" CommandParameter="{Binding SegmentNumber}"/>
                            </i:EventTrigger>
                        </i:Interaction.Triggers>
                    </Button> 
