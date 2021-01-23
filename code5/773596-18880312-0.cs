    string[] statuses = { "Rejected", "Waiting to send", "Sent", "Registered" };
    lstLetterSummary.Sort((x, y) =>
    {
         return Array.IndexOf(statuses, x.Status).CompareTo(Array.IndexOf(statuses, y.Status));
    });
