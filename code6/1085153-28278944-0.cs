    // init in 1000 for sample
    private int _outputValue = 1000; 
    
    public void versionIncrement()
    {
       _outputValue += 1; // increment 1
       lblOutput.Text = _outputValue.ToString();
       lblOutput.Visible = true;
    }
