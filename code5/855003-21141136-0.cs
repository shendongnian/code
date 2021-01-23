    <telerik:RadGridView.Columns>
        <telerik:GridViewDataColumn DataMemberBinding="{Binding Position}"/>
        <telerik:GridViewDataColumn.CellStyle>
            <Style TargetType="{x:Type telerik:GridViewCell}"
                   
                   <!--style it here -->
                   BasedOn="{StaticResource blablaStyle}">
                <Setter Property="FontWeight" Value="Bold"/>
            </Style>
        </telerik:GridViewDataColumn.CellStyle>
    </telerik:GridViewDataColumn>
