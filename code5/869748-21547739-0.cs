    private async void RunProgramClick(object sender, RoutedEventArgs e)
    {
        // Reverse the logic to reduce nesting and use "early out"
        if (comboBox1.Text != "Drive forwards and back")
        {
            return;
        }
        stop.IsEnabled = true;
        EngineA(90);
        EngineB(90);
        await Task.Delay(2000);
        EngineA(-90);
        EngineB(-90);
        
        await Task.Delay(2000);
        EngineA(0);
        EngineB(0);
        EngineC();
    }
