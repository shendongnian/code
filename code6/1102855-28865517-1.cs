    string PickNonEmptyOrDefault(string value, string deflt)
    {
        return String.IsNullOrEmpty(value) ? deflt : value;
    }
    ...
    channel.Part = PickNonEmptyOrDefault(viewModel.Part, channel.Part);
    channel.IndexName = PickNonEmptyOrDefault(viewModel.IndexName, channel.IndexName);
    etc.
