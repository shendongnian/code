        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Contains(listboxVal))
            {
                list.RemoveAt(i);
            }
        }
