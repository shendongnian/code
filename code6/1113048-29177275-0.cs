    [TestFixture]
    public class GroupBY
    {
        [Test]
        public void Test()
        {
            var list = new List<GroupContact>
            {
                new GroupContact
                {
                    GroupName = "Name01",
                    Email = "john.smith@test.com",
                    FirstName = "John",
                    LastName = "Smith"
                },
                new GroupContact
                {
                    GroupName = "Name01",
                    Email = "jane.doe@test.com",
                    FirstName = "Jane",
                    LastName = "Doe"
                },
                new GroupContact
                {
                    GroupName = "Name02",
                    Email = "bill.smith@test.com",
                    FirstName = "Bill",
                    LastName = "Smith"
                }
            };
            var res = list.GroupBy(g => g.GroupName).Select(g => new GroupEmailRecipients
            {
                GroupName = g.Key,
                EmailRecipients = g.Select(c => new EmailRecipient
                {
                    Email = c.Email,
                    FirstName = c.FirstName,
                    LastName = c.LastName
                }).ToList()
            });
            foreach (var group in res)
            {
                Console.WriteLine("Group = " + group.GroupName);
                foreach (var recipient in group.EmailRecipients)
                {
                    Console.WriteLine("\tRecipient - {0}, {1} - {2}", recipient.FirstName, recipient.LastName,recipient.Email);
                }
            }
        }
    }
