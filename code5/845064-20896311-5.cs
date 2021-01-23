    List<Key> keys;
    foreach (Key key in newInput.GetPressedKeys())
    {
        if (IsNewKeyPress(key))
            keys.Add(key);
    }
    return keys.ToArray();
