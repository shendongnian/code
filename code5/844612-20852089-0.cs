    public static void CheckItems<T>(this IEnumerable<T> items, CheckList checkList) where T : IIdentifiable
    {
        if (items != null)
        {
            foreach (T item in items)
            {
               for (int i = 0; i < checkList.Items.Count; i++)
               {
                    if (((T)checkList.Items[i]).ID == item.ID)
                    {
                         checkList.SetItemChecked(i, true);
                    }
               }
            }
        }
    }
