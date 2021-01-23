    public static WriteableBitmap ChangeColor(WriteableBitmap writeableBitmapOriginal, Color originalColor, Color newColor)
    {
        var writeableBitmapNew = new WriteableBitmap(writeableBitmapOriginal);
        originalColorInt = originalColor.ToInt();
        newColorInt = newColor.ToInt();
        for (int i = 0; i < writeableBitmapNew.Pixels.Length; i++)
            if (writeableBitmapNew.Pixels[i] == originalColorInt)
                writeableBitmapNew.Pixels[i] = newColorInt;
        return writeableBitmapNew;
    }
