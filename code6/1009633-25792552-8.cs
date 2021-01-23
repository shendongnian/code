    public IEnumerable<Inline> contentInlines
    {
        get {
            var inlines = new List<Inline>();
            for (var i = 0; i < _mess.data.Length; i += Char.IsSurrogatePair(_mess.data, i) ? 2 : 1)
            {
                var x = Char.ConvertToUtf32(_mess.data, i);
                if (EmojiConverter.EmojiDictionary.ContainsKey(x))
                {
                    //Generate new Image from Emoji
                    var emoticonImage = new Image
                    {
                        Width = 20,
                        Height = 20,
                        Margin = new Thickness(0, -5, 0, -5),
                        Source = EmojiConverter.EmojiDictionary[x]
                    };
                    inlines.Add(emoticonImage);
                }
                else
                {
                    inlines.Add(new Run("" + _mess.data[i]));
                }
            }
            return inlines;
        }
    }
