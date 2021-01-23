    public sealed class MixpanelClient
    {
        public string UserAgent { get; set; }
        public static DateTime ConvertToDateTime(long unixDateTicks);
        public static string ConvertToMixpanelDate(DateTime dateTime);
        public void CreateAlias(string token, string originalId, string newId);
        public static MixpanelClient GetCurrentClient();
        public void SaveElement(MixpanelEntity element);
        public static long ToEpochTime(DateTime date);
        public void Track(MixpanelEntity element);
        public void TrySendLocalElements();
    }
