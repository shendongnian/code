    enum TicketStatus
    {
        [GuidValue("7ae15a71-6514-4559-8ea6-06b9ddc7a59a")]
        Open,
        [GuidValue("41f81283-57f9-4bda-a03c-f632bd4d1628")]
        Closed,
        [GuidValue("41bcc323-258f-4e58-95be-e995a78d2ca8")]
        Hold
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GuidBackedEnums.CreateFromGuid<TicketStatus>(new Guid("41f81283-57f9-4bda-a03c-f632bd4d1628")));
            Console.WriteLine(GuidBackedEnums.GetGuid(TicketStatus.Hold));
        }
    }
