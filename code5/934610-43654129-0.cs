    public static class IntentExtension
    {
        public static Intent PutExtra<TExtra>(this Intent intent, string name, TExtra extra)
        { 
            var json = JsonConvert.SerializeObject(extra);
            intent.PutExtra(name, json);
            return intent;
        }
        public static TExtra GetExtra<TExtra>(this Intent intent, string name)
        {
            var json = intent.GetStringExtra(name);
            if (string.IsNullOrWhiteSpace(json))
            {
                return default(TExtra);
            }
            return JsonConvert.DeserializeObject<TExtra>(json);
        }
    }
