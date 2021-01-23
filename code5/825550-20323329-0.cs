    void Binding_Parse(object sender, ConvertEventArgs e)
    {
        var binding = (Binding)sender;
        try
        {
            binding.Parse -= Binding_Parse; // remove this event handler
            binding.WriteValue(); // try write control's value to data source
            errorProvider1.SetError(binding.Control, "");
        }
        catch (Exception error)
        {
            errorProvider1.SetError(binding.Control, error.Message);
        }
        finally
        {
            binding.Parse += Binding_Parse; // subscribe back
        }
    }
