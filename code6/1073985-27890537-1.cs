    ((Run)_inlineCollection[index]).Background = null;
    index++;
    while (index < inlineCollection.Count && !(_inlineCollection[index] is Run))
    {
        index++;
    }
    if (index < _inlineCollection.Count)
    {
        ((Run)_inlineCollection[index]).Background = BackgroundColor;
    }
