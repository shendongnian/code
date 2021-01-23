    public override void remove(ref T item)
    {
        // find value, if it exists
        for (int i = 0; i < next; i++)
        {
            if (item.Equals(list[i]))
            {
                list[i] = list[next-1];
                list[next-1] = default(T);
                next--;
                break;
            }
        }
    }
