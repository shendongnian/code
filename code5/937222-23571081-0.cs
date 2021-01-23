    public string Value
        {
            get
            {
                var sb = new StringBuilder();
                if (_nestedMultiItemStrings)
                {
                    foreach (var MultiItemString in _nestedItems)
                    {
                        sb.Append(MultiItemString.Value);
                    }
                }
                else
                {
                    foreach (var key in _keys)
                    {
                        sb.Append(_resourceKey ? (string)Application.Current.Resources[key] : key);
                    }
                }
                return sb.ToString();
            }
    set{
    _thisShouldBeAValidField = value;
    }
        }
