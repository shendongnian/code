    public class CustomAdoDelegate : StdAdoDelegate
    {
        protected override string GetSelectNextTriggerToAcquireSql(int maxCount)
        {
            return base.GetSelectNextTriggerToAcquireSql(maxCount)
                .Replace(ColumnNextFireTime + " ASC", "\0")
                .Replace(ColumnPriority + " DESC", ColumnNextFireTime + " ASC")
                .Replace("\0", ColumnPriority + " DESC");
        }
    }
