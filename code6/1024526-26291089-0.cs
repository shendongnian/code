    using System.Threading.Tasks;
    // don't forget the async
    private async void Auto_Click(object sender, RoutedEventArgs e)
    {    
        button3_Click(this, null);
        await Task.Delay(TimeSpan.FromMilliseconds(250));
        button_addition_Click(this, null);
        await Task.Delay(TimeSpan.FromMilliseconds(250));
        button7_Click(this, null);
        await Task.Delay(TimeSpan.FromMilliseconds(250));
        button_result_Click(this, null);    
        await Task.Delay(TimeSpan.FromMilliseconds(250));
    }
