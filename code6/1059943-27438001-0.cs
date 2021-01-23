    public MyClass()
    {
        DeleteClassFromeNode = data =>
        {
            Tuple<itemType1, itemType2> items = data as Tuple<itemType1, itemType2>;
            if (items != null && items.Item2 != null)
            {
              DeleteClass(items.Item2); // This is my non static method in the same class.
            }
        };
        // Other initialization code can go here (or before...whatever is most appropriate)
    }
