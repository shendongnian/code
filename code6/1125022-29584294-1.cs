    public class MultiKeyGestureConverter : TypeConverter
    {
        private readonly KeyConverter _keyConverter;
        private readonly ModifierKeysConverter _modifierKeysConverter;
    
        public MultiKeyGestureConverter()
        {
            _keyConverter = new KeyConverter();
            _modifierKeysConverter = new ModifierKeysConverter();
        }
    
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }
    
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var keyStrokes = (value as string).Split(',');
            var firstKeyStroke = keyStrokes[0];
            var firstKeyStrokeParts = firstKeyStroke.Split('+');
    
            var modifierKeys = (ModifierKeys)_modifierKeysConverter.ConvertFrom(firstKeyStrokeParts[0]);
            var keys = new List<Key>();
    
            keys.Add((Key)_keyConverter.ConvertFrom(firstKeyStrokeParts[1]));
    
            for (var i = 1; i < keyStrokes.Length; ++i)
            {
                keys.Add((Key)_keyConverter.ConvertFrom(keyStrokes[i]));
            }
    
            return new MultiKeyGesture(keys, modifierKeys);
        }
    }
