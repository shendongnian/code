    protected override Task OnWriteToStreamAsync(
        Type type,
        object value,
        Stream stream,
        HttpContentHeaders contentHeaders,
        FormatterContext formatterContext,
        TransportContext transportContext) {
    
        writeStream(type, value, stream, contentHeaders);
        var tcs = new TaskCompletionSource<int>();
        tcs.SetResult(0);
        return tcs.Task;
    }
    
    private void writeStream(Type type, object value, Stream stream, HttpContentHeaders contentHeaders) {
    
        //NOTE: We have check the type inside CanWriteType method
        //If request comes this far, the type is IEnumerable. We are safe.
    
        Type itemType = type.GetGenericArguments()[0];
    
        StringWriter _stringWriter = new StringWriter();
    
        _stringWriter.WriteLine(
            string.Join<string>(
                ",", itemType.GetProperties().Select(x => x.Name )
            )
        );
    
        foreach (var obj in (IEnumerable<object>)value) {
    
            var vals = obj.GetType().GetProperties().Select(
                pi => new { 
                    Value = pi.GetValue(obj, null)
                }
            );
    
            string _valueLine = string.Empty;
    
            foreach (var val in vals) {
    
                if (val.Value != null) {
    
                    var _val = val.Value.ToString();
    
                    //Check if the value contans a comma and place it in quotes if so
                    if (_val.Contains(","))
                        _val = string.Concat("\"", _val, "\"");
    
                    //Replace any \r or \n special characters from a new line with a space
                    if (_val.Contains("\r"))
                        _val = _val.Replace("\r", " ");
                    if (_val.Contains("\n"))
                        _val = _val.Replace("\n", " ");
    
                    _valueLine = string.Concat(_valueLine, _val, ",");
    
                } else {
    
                    _valueLine = string.Concat(string.Empty, ",");
                }
            }
    
            _stringWriter.WriteLine(_valueLine.TrimEnd(','));
        }
    
        var streamWriter = new StreamWriter(stream);
            streamWriter.Write(_stringWriter.ToString());
    }
