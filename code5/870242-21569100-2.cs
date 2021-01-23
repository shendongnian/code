XAML
    xmlns:local="clr-namespace:YourNameSpace"
    xmlns:sys="clr-namespace:System;assembly=mscorlib"
    <Grid>
        <TextBlock Text="{Binding Source={x:Static sys:DateTime.Now}, StringFormat={x:Static Member=local:StringFormats.DateFormat}}" 
                   HorizontalAlignment="Right" />
        
        <TextBlock Text="{Binding Source={x:Static sys:DateTime.Now}, StringFormat={x:Static Member=local:StringFormats.Time}}" />
    </Grid>
Code behind
    public class StringFormats 
    {
        public static string DateFormat = "Date: {0:dddd}";
        public static string Time = "Time: {0:HH:mm}";
    }   
