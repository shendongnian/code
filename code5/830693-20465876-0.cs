    class MessageExtensions
    {
        public static Message Update(this MessageUpdater updater, Dictionary<int,Message> dict, int key)
        {
            Message value = dict[key];
            MessageUpdater.Update(ref value);
            return dict[key];
        }
    }
