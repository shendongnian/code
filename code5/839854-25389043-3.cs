    public static T? ToNullable<T>(this XElement element) where T : struct
    {
        var result = new T?();
        if (element != null)
        {
            if (element.HasElements) throw new ArgumentException(String.Format("Cannot convert complex element to Nullable<{0}>", typeof(T).Name));
            var s = element.Value;
            try
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    var numConverter = ConverterFactory<T>();
                    if (numConverter != null)
                    {
                        // interface returns back object so need to cast it
                        result = (T)numConverter.ConvertFrom(s);
                    }
                    else
                    {
                        var conv = TypeDescriptor.GetConverter(typeof(T));
                        result = (T)conv.ConvertFrom(s);
                    }
                }
            }
            catch { }
        }
        return result;
    }
