    public static bool TryReceive<T>(this BufferBlock<T> bufferBlock, int count, out IList<T> items)
    {
        items = new List<T>();   
        for (var i = 0; i < count; i++)
        {
            T item;
            if (bufferBlock.TryReceive(out item))
            {
                items.Add(item);
            }
            else
            {
                break;
            }
        }
        return items.Any();
    }
