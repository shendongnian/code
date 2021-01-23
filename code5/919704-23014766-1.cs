    private void CheckValue<T>(T temp, ref T variable)
    {
        if (temp != variable)
        {
            variable = temp;
            EditorUtility.SetDirty(target);
        }
    }
