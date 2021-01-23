        private void SaveToInbox(ShortMessages shortMessage)
        {
            var now = shortMessage.MessageDate.HasValue ? shortMessage.MessageDate.Value : DateTime.Now;
            var d = new Date((now.Year - 1900), now.Month - 1, now.Day, now.Hour, now.Minute, now.Second);
            var context = Application.Context.ApplicationContext;
            var values = new ContentValues();
            values.Put("address", shortMessage.From);
            values.Put("body", shortMessage.Message);
            values.Put("read", false);
            values.Put("date", d.Time);
            context.ContentResolver.Insert(Android.Net.Uri.Parse("content://sms/inbox"), values);
        }
