    <StackPanel Name="stackPanel1">
      <StackPanel.BindingGroup>
        <BindingGroup NotifyOnValidationError="True">
          <BindingGroup.ValidationRules>
            <src:ValidateDateAndPrice ValidationStep="ConvertedProposedValue" />
          </BindingGroup.ValidationRules>
        </BindingGroup>
      </StackPanel.BindingGroup>
    
      <HeaderedContentControl Header="Price">
        <TextBox Name="priceField"  Width="150">
          <TextBox.Text>
            <Binding Path="Price" Mode="TwoWay" />
          </TextBox.Text>
        </TextBox>
      </HeaderedContentControl>
    
      <HeaderedContentControl Header="Date Offer Ends">
        <TextBox Name="dateField" Width="150" >
          <TextBox.Text>
            <Binding Path="OfferExpires" StringFormat="d" />
          </TextBox.Text>
        </TextBox>
      </HeaderedContentControl>
    
      <StackPanel Orientation="Horizontal">
        <Button IsDefault="True" Click="Submit_Click">_Submit</Button>
        <Button IsCancel="True" Click="Cancel_Click">_Cancel</Button>
      </StackPanel>
    </StackPanel>
