    <ControlTemplate x:Key="TextBoxErrorTemplate">
        <StackPanel>
            <StackPanel Orientation="Horizontal">
                <Image Height="16" Margin="0,0,5,0" 
                        Source="Assets/warning_48.png"/>
                <AdornedElementPlaceholder x:Name="Holder"/>
            </StackPanel>
            <Label Foreground="Red" Content="{Binding ElementName=Holder, 
                   Path=AdornedElement.(Validation.Errors)[0].ErrorContent}"/>
        </StackPanel>
    </ControlTemplate> 
    <TextBox x:Name="Box" 
             Validation.ErrorTemplate="{StaticResource TextBoxErrorTemplate}">
        <TextBox.Text>
            <Binding Path="ValueInBox" UpdateSourceTrigger="PropertyChanged">
                <Binding.ValidationRules>
                    <ValidationExpamples:DoubleRangeRule Min="0.5" Max="10"/>
                </Binding.ValidationRules>
            </Binding>
        </TextBox.Text>           
    </TextBox>
    
    
        public class IntRangeRule : ValidationRule
        {
            private int _min;
            private int _max;
    
            public IntRangeRule()
            {
            }
    
            public int Min
            {
                get { return _min; }
                set { _min = value; }
            }
    
            public int Max
            {
                get { return _max; }
                set { _max = value; }
            }
    
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                int l_input = 0;
    
                try
                {
                    if (((string)value).Length > 0)
                    {
                        l_input = Int32.Parse((String)value);
                    }
                }
                catch (Exception e)
                {
                    return new ValidationResult(false, "Illegal characters or " + e.Message);
                }
    
                if ((l_input < Min) || (l_input > Max))
                {
                    return new ValidationResult(false, "Please enter an value in the range: " + Min + " - " + Max + ".");
                }
    
                return new ValidationResult(true, null);
            }
        }
